using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.Base;
using KodluyoruzEFCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KodluyoruzEFCoreAPI.Controllers
{
    public class PostController : DbController
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var post = await PostService.Get();
            //await PostService.Get()
            return Ok(post);
        }
    }
}
