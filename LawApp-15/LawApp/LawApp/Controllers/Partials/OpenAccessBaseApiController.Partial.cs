using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Linq;
using Telerik.OpenAccess;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace LawAppWeb
{
    public abstract partial class OpenAccessBaseApiController<TEntity, TContext> : ApiController where TContext : OpenAccessContext, new()
    {
        public virtual IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter)
        {
            var allEntities = repository.GetWhere(filter);
            return allEntities;
        }

        public virtual IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter, params Expression<Func<object, IEnumerable<object>>>[] loadWith)
        {
            var allEntities = repository.GetWhere(filter, loadWith);
            return allEntities;
        }

        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> filter)
        {
            return repository.GetBy(filter);
        }

        public virtual TEntity AddNew(TEntity entity)
        {
            return repository.AddNew(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return repository.Update(entity);
        }
    }
}