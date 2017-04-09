using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OrangeBricks.Web.UoW
{
    internal class OrangeBrickGenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity : class
    {
        
        private readonly IDbSet<TEntity> _dbSet;

        public OrangeBrickGenericRepository(IDbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        #region IGenericRepository<TEntity> implementation

        public virtual IQueryable<TEntity> AsQueryable()
        {
            return _dbSet.AsQueryable();
        }

        /// <summary>
        /// Be carefull in using large set
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet;
        }

       
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {

            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        
           
        }

        public TEntity Single(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Single(filter);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter = null)
        {
            return _dbSet.Where(filter).SingleOrDefault();
        }

        public TEntity First(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter)?.First();
        }

             
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            TEntity entityToDelete = _dbSet.Find(entity);
            if(entityToDelete!=null)
            {
                _dbSet.Remove(entityToDelete);
            }
            
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);  
        }

        //May be for future implementation
        // Before doin this we need to check dbcontext is in detached state for this Entity

        //public virtual void Delete(TEntity entityToDelete)
        //{

        //    _dbSet.Remove(entityToDelete);
        //}

        //public virtual void Update(TEntity entityToUpdate)
        //{
        //    _dbSet.Attach(entityToUpdate);

        //}

        #endregion
    }
}