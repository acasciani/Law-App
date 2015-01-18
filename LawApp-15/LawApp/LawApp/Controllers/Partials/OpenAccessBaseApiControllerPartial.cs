using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using Telerik.OpenAccess;
using System.Linq.Expressions;
using System;

namespace LawAppWeb
{
    public abstract partial class OpenAccessBaseApiController<TEntity, TContext> : ApiController where TContext : OpenAccessContext, new()
    {
        public virtual IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter)
        {
            var allEntities = ((LawAppWeb.OpenAccessBaseRepository<TEntity, TContext>)repository).GetWhere(filter);

            return allEntities;
        }

        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> filter)
        {
            return repository.GetBy(filter);
        }
    }
}