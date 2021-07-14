using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IProductService _productService;

        private ICategoryService _categoryService;

        private const int pageSize = 6; // number of products per page

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;

            _productService = productService;
            // here again dependency injection

            _categoryService = categoryService;
            // here again dependency injection
        }

        [Route("/")]
        public IActionResult Index(int page = 1)
        {

            /* bring Products and Categories into Front-end */
            var theProductListModel = new ProductListViewModel()
            {
                PaginationInformation = new PageInfo
                {
                    TotalItems = _productService.GetAll().Count(),
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    CurrentCategory = null
                },
                Products = _productService.GetProductsByCategoryByPage(category: null ,page, pageSize)
            };
            return View(theProductListModel);
        }

      
    }
}