using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.DAL.Entities.Core;
using KodluyoruzEFCoreAPI.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace KodluyoruzEFCoreAPI.Repository
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IUnitOfWork<TContext> _unitOfWork;

        private DbSet<TEntity> _entities;
        protected virtual DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());

        public Repository(TContext context, IUnitOfWork<TContext> unitOfWork)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        public IQueryable<TEntity> Query()
            => Entities.AsQueryable().TagWith("Query Parametresi Çalıştırıldı " + nameof(TEntity));

        public ICollection<TEntity> GetAll()
            => Entities.ToList();

        public async Task<ICollection<TEntity>> GetAllAsync()
            => await Entities.TagWith("GetAllAsync Parametresi Çalıştırıldı " + nameof(TEntity)).ToListAsync();

        public TEntity GetById(int id)
            => Entities.Find(id);

        public async Task<TEntity> GetByIdAsync(int id)
            => await Entities.FindAsync(id);

        public TEntity GetByUniqueId(string id)
            => Entities.Find(id);
        public async Task<TEntity> GetByUniqueIdAsync(string id)
            => await Entities.FindAsync(id);
        public TEntity Find(Expression<Func<TEntity, bool>> match)
            => Entities.SingleOrDefault(match);
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
            => await Entities.SingleOrDefaultAsync(match);
        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
            => Entities.Where(match).ToList();
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
            => await Entities.Where(match).ToListAsync();
        public TEntity Add(TEntity entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Entities.Add(entity);
            await _unitOfWork.Commit();
            return entity;
        }
        public TEntity Update(TEntity updated)
        {
            if (updated == null)
                return null;
            Entities.Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            _context.SaveChanges();
            return updated;
        }
        public async Task<TEntity> UpdateAsync(TEntity updated)
        {
            if (updated == null)
                return null;
            Entities.Attach(updated);
            _context.Entry(updated).State = EntityState.Modified;
            await _unitOfWork.Commit();
            return updated;
        }
        public void Delete(TEntity t)
        {
            Entities.Remove(t);
            _context.SaveChanges();
        }
        public async Task<int> DeleteAsync(TEntity t)
        {
            Entities.Remove(t);
            return await _unitOfWork.Commit();
        }

        public int Count()
            => Entities.Count();

        public async Task<int> CountAsync()
            => await Entities.CountAsync();
        public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? page = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = Entities;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            return query.ToList();
        }
        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }



        public bool Exist(Expression<Func<TEntity, bool>> predicate)
        {
            var exist = Entities.Where(predicate);
            return exist.Any() ? true : false;
        }




    }
}