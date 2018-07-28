using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BCS.Directory.DAO
{
    public interface IGenericRepository<TEntity, TID>
    {
        List<TEntity> Get(
              Expression<Func<TEntity, bool>> filter = null,
              Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
               params Expression<Func<TEntity, object>>[] includes);
        TEntity GetById(object id);
        TEntity GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(object id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter
                            , params Expression<Func<TEntity, object>>[] includeProperties);
        void Reload(TEntity entity);
    }
}
