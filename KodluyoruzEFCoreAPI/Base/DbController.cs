using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KodluyoruzEFCoreAPI.Objects;
using KodluyoruzEFCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KodluyoruzEFCoreAPI.Base
{
    public class DbController : Controller
    {
        //private readonly IntegrationContext _db;
        //public IntegrationContext Db => _db ?? (IntegrationContext)HttpContext?.RequestServices.GetService(typeof(IntegrationContext));

        //private readonly IProductService _productService;
        private readonly IGeneralService<Post> _postService;
        //protected IProductService ProductService => _productService ?? (ProductService)HttpContext?.RequestServices.GetService(typeof(IProductService));
        //protected IBrandService BrandService => _brandService ?? (BrandService)HttpContext?.RequestServices.GetService(typeof(IBrandService));

        //protected IProductService ProductService => _productService ?? (ProductService)HttpContext?.RequestServices.GetService(typeof(IProductService));
        protected IGeneralService<Post> PostService => _postService ?? (PostService)HttpContext?.RequestServices.GetService(typeof(IGeneralService<Post>));
    }
}
