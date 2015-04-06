using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawAppWeb
{
    public partial class SignedWebUsersController : OpenAccessBaseApiController<LawAppModel.SignedWebUser, LawAppModel.LawApp>
    {
        public bool IsAuthorized(int signedWebUserId, string permissionName, bool isLoggedIn)
        {
            SignedWebUser user = Get(signedWebUserId);
            return IsAuthorized(user, permissionName, isLoggedIn);
        }

        internal bool IsAuthorized(SignedWebUser webUser, string permissionName, bool isLoggedIn)
        {
            bool userHasIndividualPerm = webUser.Permissions.Where(p => p.PermissionName == permissionName && (p.RequiresLogin ? isLoggedIn : true)).Count() > 0;
            if (userHasIndividualPerm) return true;

            using (UserRolesController c = new UserRolesController())
            {
                foreach(UserRole role in webUser.UserRoles){
                    bool roleHasPerm = c.IsAuthorized(role, permissionName, isLoggedIn);
                    if (roleHasPerm) return true;
                }
            }

            return false;
        }
    }
}