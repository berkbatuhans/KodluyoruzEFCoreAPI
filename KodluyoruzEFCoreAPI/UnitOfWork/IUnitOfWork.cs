using System;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.DAL.Entities.Core;
using KodluyoruzEFCoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace KodluyoruzEFCoreAPI.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        Task<int> Commit();
        void Rollback();

    }
}
