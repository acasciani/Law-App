using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawAppWeb
{
    public partial class UserRolesController : OpenAccessBaseApiController<LawAppModel.UserRole, LawAppModel.LawApp>
    {
        public bool IsAuthorized(int userRoleId, string permissionName, bool isLoggedIn)
        {
            UserRole userRole = Get(userRoleId);
            return IsAuthorized(userRole, permissionName, isLoggedIn);
        }

        internal bool IsAuthorized(UserRole userRole, string permissionName, bool isLoggedIn)
        {
            return userRole.Permissions.Where(p => p.PermissionName == permissionName && (p.RequiresLogin ? isLoggedIn : true)).Count() > 0;
        }
    }
}