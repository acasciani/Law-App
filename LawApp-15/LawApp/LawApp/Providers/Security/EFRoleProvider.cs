using LawAppModel;
using LawAppWeb;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Hosting;
using System.Web.Security;

namespace LawAppProviders.Security
{
    public class EFRoleProvider : RoleProvider
    {
        #region properties
        public override string ApplicationName { get; set; }
        private Application Application { get; set; }
        #endregion


        #region public methods
        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null) { throw new ArgumentNullException("config"); }
            if (string.IsNullOrEmpty(name)) { name = "EFRoleProvider"; }

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Law Application EF Role Provider");
            }

            // Initialize the abstract base class.
            base.Initialize(name, config);

            ApplicationName = Convert.ToString(ProviderUtils.GetConfigValue(config, "applicationName", HostingEnvironment.ApplicationVirtualPath));

            using (ApplicationsController ac = new ApplicationsController())
            {
                Application = ac.GetWhere(a => a.ApplicationName == ApplicationName).FirstOrDefault();
            }

            if (Application == null)
            {
                throw new ProviderException("Unable to find the current application.");
            }
        }

        public override void AddUsersToRoles(string[] emails, string[] roleNames)
        {
            // get all roles as objects
            IEnumerable<UserRole> roles = GetAllUserRoles().Where(r => roleNames.Contains(r.RoleName));

            if (roles == null || roles.Count() == 0) return;

            // get all users as objects
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                IEnumerable<SignedWebUser> users = swuc.GetWhere(u => emails.Contains(u.Email));

                foreach (SignedWebUser user in users)
                {
                    foreach (UserRole role in roles)
                    {
                        if (!user.UserRoles.Contains(role))
                        {
                            user.UserRoles.Add(role);
                            swuc.Update(user);
                        }
                    }
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            using (UserRolesController urc = new UserRolesController())
            {
                UserRole role = new UserRole()
                {
                    RoleName = roleName,
                    Application = Application,
                    ApplicationId = Application.ApplicationId
                };

                urc.AddNew(role);
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string emailToMatch)
        {
            IEnumerable<SignedWebUser> users;
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                users = swuc.GetWhere(u => u.Email == emailToMatch && u.UserRoles.Where(MatchApplication()).Where(r => r.RoleName == roleName).Count() > 0);
            }

            if (users == null) return new string[0];

            return users.Select(u => u.Email).ToArray();
        }

        public override string[] GetAllRoles()
        {
            IEnumerable<UserRole> roles = GetAllUserRoles();
            if (roles == null) return new string[0];

            return roles.Select(r => r.RoleName).ToArray();
        }

        public override string[] GetRolesForUser(string email)
        {
            SignedWebUser user = GetUser(u => u.Email == email);
            return user.UserRoles.Where(MatchApplication()).Select(result => result.RoleName).ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            UserRole role = GetRole(r => r.RoleName == roleName);
            if (role == null) return new string[0];

            return role.SignedWebUsers.Select(r => r.Email).ToArray();
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            SignedWebUser user = GetUser(u => u.Email == email);

            if (user == null)
            {
                // couldn't find user
                return false;
            }

            return user.UserRoles.Where(MatchApplication()).Where(r => r.RoleName == roleName).Count() == 1;
        }

        public override void RemoveUsersFromRoles(string[] emails, string[] roleNames)
        {
            IEnumerable<UserRole> roles = GetAllUserRoles().Where(r => roleNames.Contains(r.RoleName));

            if (roles == null) return;
            
            IEnumerable<SignedWebUser> users;
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                users = swuc.GetWhere(u => emails.Contains(u.Email));

                if (users == null) return;

                foreach (SignedWebUser user in users)
                {
                    foreach (UserRole role in roles) {
                        if (user.UserRoles.Contains(role))
                        {
                            user.UserRoles.Remove(role);
                            swuc.Update(user);
                        }                    
                    }
                }
            }
        }

        public override bool RoleExists(string roleName)
        {
            return GetRole(r => r.RoleName == roleName) != null;
        }
        #endregion


        #region private methods
        private SignedWebUser GetUser(Expression<Func<SignedWebUser, bool>> predicate)
        {
            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user;
                try
                {
                    user = swuc.GetWhere(predicate).FirstOrDefault();
                }
                catch (ProviderException)
                {
                    user = null;
                }

                return user;
            }
        }

        private UserRole GetRole(Func<UserRole, bool> predicate)
        {
            UserRole role = GetAllUserRoles().Where(predicate).FirstOrDefault();
            return role;
        }

        private IEnumerable<UserRole> GetAllUserRoles()
        {
            IEnumerable<UserRole> roles;
            using (UserRolesController urc = new UserRolesController())
            {
                Func<UserRole, bool> func = MatchApplication();
                roles = urc.GetWhere(r => func(r));
                
                return roles;
            }
        }

        private Func<UserRole, bool> MatchApplication()
        {
            return role => role.Application == Application;
        }
        #endregion
    }
}