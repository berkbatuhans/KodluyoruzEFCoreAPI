using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzEFCoreAPI.Services
{
    public interface IGeneralService<T>
    {
        T GetById(int id);
        Task<IEnumerable<T>> Get();
        //TODO: Create Methodu FromBody problemi giderilecek using Microsoft.AspNetCore.Mvc; paketi istiyor.
        Task<bool> Create([FromBody]T entity);
        Task<T> Add([FromBody]T entity);
        Task<bool> Update(int id, [FromBody] T entity);
        bool Delete(int id);
        Task<bool> IsExists(string name);

        Task<bool> IsExists(int id, string name);

    }
}
