using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.Data;
using KodluyoruzEFCoreAPI.Objects;
using KodluyoruzEFCoreAPI.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzEFCoreAPI.Services
{
    public class PostService : IGeneralService<Post>
    {
        private readonly IUnitOfWork<KodluyoruzDbContext> _unitOfWork;

        public PostService(IUnitOfWork<KodluyoruzDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Post>> Get()
        {
            return await _unitOfWork.GetRepository<Post>().GetAllAsync();
        }


        public async Task<Post> Add([FromBody] Post entity)
        {
            Post post = await _unitOfWork.GetRepository<Post>().AddAsync(new Post
            {
                PostId = entity.PostId,
                Title = entity.Title,
                BlogId = entity.BlogId,
                Blog = entity.Blog,
                Content = entity.Content
            });

            return post;
        }


        public async Task<bool> Create([FromBody] Post entity)
        {
            Post post = await _unitOfWork.GetRepository<Post>().AddAsync(new Post
            {
                PostId = entity.PostId,
                Title = entity.Title,
                BlogId = entity.BlogId,
                Blog = entity.Blog,
                Content = entity.Content
            });

            return post != null && post.PostId != 0;
        }


        public async Task<bool> IsExists(string name)
            => await _unitOfWork.GetRepository<Post>().FindAsync(x => string.Equals(x.Title, name, StringComparison.CurrentCultureIgnoreCase)) != null;

        public async Task<bool> IsExists(int id, string name) =>
            await _unitOfWork.GetRepository<Post>().FindAsync(x => x.PostId != id && string.Equals(x.Title, name, StringComparison.CurrentCultureIgnoreCase)) != null;





        

        public async Task<bool> Update(int id, [FromBody] Post entity)
        {
            Post post = await _unitOfWork.GetRepository<Post>().UpdateAsync(new Post
            {
                PostId = entity.PostId,
                Title = entity.Title,
            });

            return post != null;
        }

        public Post GetById(int id)
        {
            Post post = _unitOfWork.GetRepository<Post>().FindAsync(x => x.PostId == id).Result;

            if (post == null)
            {
                return new Post();
            }

            return new Post
            {
                Title = post.Title,
                PostId = post.PostId,
            };
        }

        //public async Task<IActionResult> Delete(Post entity)
        //{
        //    await _unitOfWork.GetRepository<Post>().DeleteAsync(entity);
        //    await _unitOfWork.Commit();
        //    return (IActionResult)entity;
        //}
        public bool Delete(int id)
        {
            Task<int> result = _unitOfWork.GetRepository<Post>().DeleteAsync(new Post { PostId = id });

            return Convert.ToBoolean(result.Result);
        }

        


    }
}
