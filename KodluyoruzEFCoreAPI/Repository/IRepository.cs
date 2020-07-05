using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.DAL.Entities.Core;

namespace KodluyoruzEFCoreAPI.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {

        IQueryable<TEntity> Query();

        ICollection<TEntity> GetAll();

        Task<ICollection<TEntity>> GetAllAsync();


        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);

        TEntity GetByUniqueId(string id);
        Task<TEntity> GetByUniqueIdAsync(string id);

        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);


        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);

        TEntity Update(TEntity updated);
        Task<TEntity> UpdateAsync(TEntity entity);

        void Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);

        int Count();
        Task<int> CountAsync();

        IEnumerable<TEntity> Filter(
            Expression<Func<TEntity, bool>> filterPredicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByPredicate = null,
            string navigationProperties = "",
            int? page = null,
            int? pageSiz = null);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        bool Exist(Expression<Func<TEntity, bool>> predicate);
    }
}