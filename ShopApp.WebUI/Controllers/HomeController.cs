using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;
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

        public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
        {
            _logger = logger;

            _productService = productService;
            // here again dependency injection

            _categoryService = categoryService;
            // here again dependency injection
        }

        [Route("/")]
        public IActionResult Index()
        {
            /* bring Products and Categories into Front-end */
            var theProductListModel = new ProductListModel()
            {
                Products = _productService.GetAll()
            };
            return View(theProductListModel);
        }

      
    }
}