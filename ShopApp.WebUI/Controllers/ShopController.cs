using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        /* shop controller is for user pages */

        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
            // dependency injection
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            /* this controller is for listing all the products in the app */

            /* return all the products to the rendering */
            var allTheProducts = new ProductListModel() {
                Products = _productService.GetAll()
            };

            return View(allTheProducts);
        }
    }
}
