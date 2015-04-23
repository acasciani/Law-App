using LawAppModel;
using LawAppWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Telerik.OpenAccess;

namespace LawAppWeb
{
    public partial class TSC_UniqueDaysController : OpenAccessBaseApiController<LawAppModel.TSC_UniqueDays, LawAppModel.LawApp>
    {

        public int DeleteAll(Expression<Func<TSC_UniqueDays, bool>> where)
        {
            int currentLoggedInUserId = Authorization.CurrentUser.WebUserId; // should make sure current user CAN delete 
            using (LawApp context = new LawApp())
            {
                IQueryable<TSC_UniqueDays> query = context.GetAll<TSC_UniqueDays>().Where(i => i.WebUserId == currentLoggedInUserId).Where(where);
                if (query.Count() > 0)
                {
                    return query.DeleteAll();
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}