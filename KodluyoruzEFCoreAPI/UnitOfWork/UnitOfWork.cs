using System;
using System.Linq;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.DAL.Entities.Core;
using KodluyoruzEFCoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KodluyoruzEFCoreAPI.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            this._context = context;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return new Repository<TEntity, TContext>(_context, this);
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
