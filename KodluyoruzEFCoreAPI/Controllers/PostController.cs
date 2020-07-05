using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.Base;
using KodluyoruzEFCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzEFCoreAPI.Controllers
{
    public class PostController : DbController
    {
        /// <summary>
        /// Post Servisini Getirir
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/posts")]
        public async Task<IActionResult> Index()
        {
            var post = await PostService.Get();
            //await PostService.Get()
            return Ok(post);
        }

        /// <summary>
        /// Post Servisini Getirir
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/posts/add")]
        public async Task<IActionResult> Add()
        {
            var post = await PostService.Get();
            //await PostService.Get()
            return Ok(post);
        }

        /// <summary>
        /// Post Servisini Getirir
        /// </summary>
        /// <returns></returns>
        [HttpPut("api/posts/update")]
        public async Task<IActionResult> Update()
        {
            var post = await PostService.Get();
            //await PostService.Get()
            return Ok(post);
        }
        /// <summary>
        /// Post Servisini Getirir
        /// </summary>
        /// <returns></returns>
        [HttpDelete("api/posts/delete")]
        public async Task<IActionResult> Delete()
        {
            var post = await PostService.Get();
            //await PostService.Get()
            return Ok(post);
        }
    }
}
