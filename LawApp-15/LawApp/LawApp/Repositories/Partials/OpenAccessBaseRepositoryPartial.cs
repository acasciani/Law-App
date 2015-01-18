using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Telerik.OpenAccess;
using Telerik.OpenAccess.FetchOptimization;

namespace LawAppWeb
{
    public abstract partial class OpenAccessBaseRepository<TEntity, TContext> : IOpenAccessBaseRepository<TEntity, TContext> where TContext : OpenAccessContext, new()
    {
        public virtual IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException("filter");

            List<TEntity> allEntities = dataContext.GetAll<TEntity>().Where<TEntity>(filter).ToList<TEntity>();

            List<TEntity> detachedEntities = dataContext.CreateDetachedCopy<List<TEntity>>(allEntities, fetchStrategy);

            return detachedEntities.AsQueryable();
        }
    }
}