﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Provider;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Security;
using LawAppModel;
using LawAppWeb;
using System.Net.Http;

namespace LawAppProviders.Security
{
    public class EFMembershipProvider : MembershipProvider
    {
        #region members
        private const int NEWPASSWORDLENGTH = 8;
        private bool enablePasswordReset;
        private bool enablePasswordRetrieval;
        private MachineKeySection machineKey; // Used when determining encryption key values.
        private int maxInvalidPasswordAttempts;
        private int minRequiredNonAlphanumericCharacters;
        private int minRequiredPasswordLength;
        private int passwordAttemptWindow;
        private MembershipPasswordFormat passwordFormat;
        private string passwordStrengthRegularExpression;
        private bool requiresQuestionAndAnswer;
        private bool requiresUniqueEmail;
        #endregion

        #region properties
        public override bool EnablePasswordRetrieval { get { return enablePasswordRetrieval; } }
        public override bool EnablePasswordReset { get { return enablePasswordReset; } }
        public override bool RequiresQuestionAndAnswer { get { return requiresQuestionAndAnswer; } }
        public override string ApplicationName { get; set; }
        public override int MaxInvalidPasswordAttempts { get { return maxInvalidPasswordAttempts; } }
        public override int PasswordAttemptWindow { get { return passwordAttemptWindow; } }
        public override bool RequiresUniqueEmail { get { return requiresUniqueEmail; } }
        public override MembershipPasswordFormat PasswordFormat { get { return passwordFormat; } }
        public override int MinRequiredPasswordLength { get { return minRequiredPasswordLength; } }
        public override int MinRequiredNonAlphanumericCharacters { get { return minRequiredNonAlphanumericCharacters; } }
        public override string PasswordStrengthRegularExpression { get { return passwordStrengthRegularExpression; } }
        public string ConnectionString { get; set; }
        #endregion

        #region public methods
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null) { throw new ArgumentNullException("config"); }
            if (string.IsNullOrEmpty(name)) { name = "EFMembershipProvider"; }

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Law Application EF Membership Provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            ApplicationName = Convert.ToString(ProviderUtils.GetConfigValue(config, "applicationName", HostingEnvironment.ApplicationVirtualPath));
            maxInvalidPasswordAttempts = Convert.ToInt32(ProviderUtils.GetConfigValue(config, "maxInvalidPasswordAttempts", "5"));
            passwordAttemptWindow = Convert.ToInt32(ProviderUtils.GetConfigValue(config, "passwordAttemptWindow", "10"));
            minRequiredNonAlphanumericCharacters = Convert.ToInt32(ProviderUtils.GetConfigValue(config, "minRequiredNonAlphanumericCharacters", "1"));
            minRequiredPasswordLength = Convert.ToInt32(ProviderUtils.GetConfigValue(config, "minRequiredPasswordLength", "6"));
            passwordStrengthRegularExpression = Convert.ToString(ProviderUtils.GetConfigValue(config, "passwordStrengthRegularExpression", string.Empty));
            enablePasswordReset = Convert.ToBoolean(ProviderUtils.GetConfigValue(config, "enablePasswordReset", "true"));
            enablePasswordRetrieval = Convert.ToBoolean(ProviderUtils.GetConfigValue(config, "enablePasswordRetrieval", "false"));
            requiresQuestionAndAnswer = Convert.ToBoolean(ProviderUtils.GetConfigValue(config, "requiresQuestionAndAnswer", "true"));
            requiresUniqueEmail = Convert.ToBoolean(ProviderUtils.GetConfigValue(config, "requiresUniqueEmail", "false"));

            if (!string.IsNullOrEmpty(passwordStrengthRegularExpression))
            {
                passwordStrengthRegularExpression = passwordStrengthRegularExpression.Trim();
                if (!string.IsNullOrEmpty(passwordStrengthRegularExpression))
                {
                    try
                    {
                        new Regex(passwordStrengthRegularExpression);
                    }
                    catch (ArgumentException ex)
                    {
                        throw new ProviderException(ex.Message, ex);
                    }
                }

                if (minRequiredPasswordLength < minRequiredNonAlphanumericCharacters)
                {
                    throw new ProviderException("Minimal required non alphanumeric characters cannot be longer than the minimum required password length.");
                }
            }

            string temp_format = config["passwordFormat"] ?? "Hashed";

            switch (temp_format)
            {
                case "Hashed":
                    passwordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    passwordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    passwordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("Password format not supported.");
            }

            // Initialize SqlConnection.
            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[config["connectionStringName"]];
            if (connectionStringSettings == null || connectionStringSettings.ConnectionString.Trim() == string.Empty)
            {
                throw new ProviderException("Connection string cannot be blank.");
            }

            ConnectionString = connectionStringSettings.ConnectionString;

            // Get encryption and decryption key information from the configuration.
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)configuration.GetSection("system.web/machineKey");

            if (machineKey.ValidationKey.Contains("AutoGenerate"))
            {
                if (PasswordFormat != MembershipPasswordFormat.Clear)
                {
                    throw new ProviderException("Hashed or Encrypted passwords are not supported with auto-generated keys.");
                }
            }
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            // Validate email/password
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }

            // Check whether user with passed username already exists
            MembershipUser user;
            try
            {
                user = GetUser(username, false);
            }
            catch (ProviderException)
            {
                user = null;
            }

            if (user == null)
            {
                DateTime creationDate = DateTime.Now;

                if (providerUserKey != null)
                {
                    if (!(providerUserKey is Int32))
                    {
                        status = MembershipCreateStatus.InvalidProviderUserKey;
                        return null;
                    }
                }
                
                // Need to add roles
                SignedWebUser newUser = new SignedWebUser
                {
                    Email = username,
                    CreationDate = creationDate,
                    UserPassword = EncodePassword(password)
                };

                try
                {
                    SignedWebUser response;

                    using (SignedWebUsersController wuc = new SignedWebUsersController())
                    {
                        response = wuc.AddNew(newUser);
                    }

                    status = (response != null) ? MembershipCreateStatus.Success : MembershipCreateStatus.ProviderError;
                }
                catch(Exception)
                {
                    status = MembershipCreateStatus.UserRejected;
                }

                return GetUser(username, false);
            }

            status = MembershipCreateStatus.DuplicateUserName;

            return null;
        }

        public override bool ChangePasswordQuestionAndAnswer(string email, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException("Not currently able to change password question and answer");
        }

        public override string GetPassword(string username, string answer)
        {
            if (!EnablePasswordRetrieval)
            {
                throw new ProviderException("Password Retrieval Not Enabled.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Hashed)
            {
                throw new ProviderException("Cannot retrieve Hashed passwords.");
            }

            string password = string.Empty;
            using (SignedWebUsersController wuc = new SignedWebUsersController())
            {
                SignedWebUser user = wuc.GetWhere(swu => swu.Email.Equals(username)).FirstOrDefault();

                if (PasswordFormat == MembershipPasswordFormat.Encrypted)
                {
                    password = UnEncodePassword(user.UserPassword);
                }
            }

            return password;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            // Check if user is authenticated
            if (!ValidateUser(username, oldPassword))
            {
                return false;
            }

            // Notify that password is going to change
            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPassword, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                if (args.FailureInformation != null)
                {
                    throw args.FailureInformation;
                }

                throw new MembershipPasswordException("Change password canceled due to new password validation failure.");
            }

            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user = swuc.GetWhere(u => u.Email == username).FirstOrDefault();

                user.UserPassword = EncodePassword(newPassword);
                user.ModificationDate = DateTime.Now;

                try
                {
                    swuc.Update(user);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        public override string ResetPassword(string username, string answer)
        {
            if (!EnablePasswordReset)
            {
                throw new NotSupportedException("Password reset is not enabled.");
            }

            if (answer == null && RequiresQuestionAndAnswer)
            {
                throw new ProviderException("Password answer required for password reset.");
            }

            string newPassword = Membership.GeneratePassword(NEWPASSWORDLENGTH, MinRequiredNonAlphanumericCharacters);

            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, newPassword, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                if (args.FailureInformation != null)
                {
                    throw args.FailureInformation;
                }

                throw new MembershipPasswordException("Reset password canceled due to password validation failure.");
            }

            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user = swuc.GetWhere(u => u.Email == username).FirstOrDefault();

                try
                {
                    user.UserPassword = EncodePassword(newPassword);
                    swuc.Update(user);
                    return newPassword;
                }
                catch
                {
                    throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
                }
            }
        }

        public override void UpdateUser(MembershipUser membershipUser)
        {
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user = swuc.GetWhere(u => u.Email == membershipUser.UserName).FirstOrDefault();
                user.Email = membershipUser.UserName;
                swuc.Put(user.WebUserId, user);
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            SignedWebUser user = GetUser(u => (u.Email == username && u.UserPassword == EncodePassword(password)));
            return user != null;
        }

        public override bool UnlockUser(string username)
        {
            throw new NotImplementedException("Unlock user not implemented");
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            Expression<Func<SignedWebUser, bool>> search = user => (user.WebUserId == (Int32)providerUserKey);
            return GetUser(search, userIsOnline);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            Expression<Func<SignedWebUser, bool>> search = user => (user.Email == username);
            return GetUser(search, userIsOnline);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            try
            {
                using (SignedWebUsersController swuc = new SignedWebUsersController())
                {
                    SignedWebUser user;
                    try
                    {
                        user = swuc.GetWhere(u => u.Email == username).FirstOrDefault();
                        if (user == null)
                        {
                            return false;
                        }
                    }
                    catch (ProviderException)
                    {
                        return false;
                    }

                    swuc.Delete(user.WebUserId);

                    // Need to delete all user related data (Mark as historical)

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection users = new MembershipUserCollection();

            // Retrieve all users for the current application name from the database
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                IEnumerable<SignedWebUser> usersInApplication = swuc.GetWhere(MatchApplication());

                totalRecords = usersInApplication.Distinct().Count();
                if (totalRecords <= 0)
                {
                    return users;
                }

                IEnumerable<SignedWebUser> userEntities = usersInApplication.OrderBy(u => u.Email).Skip(pageIndex * pageSize).Take(pageSize);
                foreach (SignedWebUser user in userEntities)
                {
                    users.Add(GetMembershipUserFromPersistedEntity(user));
                }

                return users;
            }
        }

        public override int GetNumberOfUsersOnline()
        {
            TimeSpan onlineSpan = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
            DateTime compareTime = DateTime.Now.Subtract(onlineSpan);

            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                //return swuc.GetWhere(MatchApplication()).Where(u => u.LastActivityDate > compareTime).Distinct().Count();
            }

            throw new NotImplementedException("Get number of online users not currently implemented");
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("Find users by name not currently implemented");
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException("Find users by email not implemented");
        }

        public override string GetUserNameByEmail(string email)
        {
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user = swuc.GetBy(u => u.Email == email);
                return (user == null) ? "" : user.Email;
            }
        }

        public static bool CheckUser(string email, string applicationName)
        {
            throw new NotImplementedException("Check user not currently implemented");
        }
        #endregion


        #region private methods
        private MembershipUser GetUser(Expression<Func<SignedWebUser, bool>> search, bool userIsOnline)
        {
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                MembershipUser membershipUser = null;
                SignedWebUser user;
                try
                {
                    user = swuc.GetWhere(search).FirstOrDefault();
                }
                catch (ProviderException)
                {
                    user = null;
                }

                if (user != null)
                {
                    membershipUser = GetMembershipUserFromPersistedEntity(user);

                    if (userIsOnline)
                    {
                        // modify online
                        //user.LastActivityDate = DateTime.Now;
                        //context.SaveChanges();
                    }
                }

                return membershipUser;
            }
        }

        private MembershipUser GetMembershipUserFromPersistedEntity(SignedWebUser user)
        {
            return new MembershipUser(Name,
                user.Email,
                user.WebUserId,
                user.Email,
                null,
                null,
                true,
                false,
                Convert.ToDateTime(user.CreationDate),
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue,
                DateTime.MinValue);
        }

        private SignedWebUser GetUser(Expression<Func<SignedWebUser, bool>> query)
        {
            SignedWebUser user;

            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                user = swuc.GetWhere(query).Where(MatchApplication()).FirstOrDefault();
            }

            /*
            if (user == null)
            {
                throw new ProviderException("The requested user could not be found.");
            }
            */

            return user;
        }

        private Expression<Func<SignedWebUser, bool>> MatchApplication()
        {
            Application app;
            using(ApplicationsController ac = new ApplicationsController()){
                app = ac.GetWhere(a =>a.ApplicationName == ApplicationName).FirstOrDefault();
            }

            if(app == null){
                throw new ProviderException("Unable to find the current application.");
            }

            // The user should have at least one role for this app. If they don't they don't match the application spec.
            return user => (user.UserRoles.Where(r => r.Application.ApplicationId == app.ApplicationId).Count() > 0);
        }

        private void UpdateFailureCount(string username, string failureType)
        {
            throw new NotImplementedException("Update failure count is not implemented yet.");
        }

        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            return pass1 == pass2;
        }

        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1 { Key = HexToByte(machineKey.ValidationKey) };
                    encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return encodedPassword;
        }

        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    break;
                case MembershipPasswordFormat.Encrypted:
                    password = Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("Unsupported password format.");
            }

            return password;
        }

        private static byte[] HexToByte(string hexString)
        {
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return returnBytes;
        }
        #endregion
    }
}
