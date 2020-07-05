using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.Data;
using KodluyoruzEFCoreAPI.Objects;
using KodluyoruzEFCoreAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzEFCoreAPI.Services
{
    public class BlogService : IGeneralService<Blog>
    {
        private readonly IUnitOfWork<KodluyoruzDbContext> _unitOfWork;

        public BlogService(IUnitOfWork<KodluyoruzDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Blog>> Get()
        {
            return await _unitOfWork.GetRepository<Blog>().GetAllAsync();
        }

        public Task<Blog> Add([FromBody] Blog entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create([FromBody] Blog entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        

        public Blog GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id, string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int id, [FromBody] Blog entity)
        {
            throw new NotImplementedException();
        }
    }
}
