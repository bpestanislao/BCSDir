using BCS.Directory.CORE.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BCS.Directory.DAO
{
    public class GenericRepository<TEntity, T> : IGenericRepository<TEntity, T>
       where TEntity : EntityBase<T>, new()
    {
        private IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual void Reload(TEntity entity)
        {
            _unitOfWork.Context.Entry<TEntity>(entity).Reload();
        }
        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _unitOfWork.Context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter);
        }

        public virtual void Insert(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var oldValueOfEntity = _unitOfWork.Context.Set<TEntity>().Find(entity.Id);
            if (oldValueOfEntity != null)
            {
                _unitOfWork.Context.Entry(oldValueOfEntity).CurrentValues.SetValues(entity);
            }

        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _unitOfWork.Context.Set<TEntity>().Find(id);
            if (_unitOfWork.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _unitOfWork.Context.Set<TEntity>().Attach(entityToDelete);
            }
            _unitOfWork.Context.Set<TEntity>().Remove(entityToDelete);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetQuery(includeProperties).Where(filter);
        }

        public virtual IQueryable<TEntity> GetQuery(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return IncludeProperties(includeProperties, _unitOfWork.Context.Set<TEntity>());
        }

        private IQueryable<TEntity> IncludeProperties(Expression<Func<TEntity, object>>[] includeProperties, DbSet<TEntity> dbSet)
        {
            var result = dbSet.AsQueryable();
            foreach (var includeProperty in includeProperties)
                result = result.Include(includeProperty);
            return result;
        }
    }
}
