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
            var allTheProducts = new ProductListModel()
            {
                Products = _productService.GetAll()
            };

            return View(allTheProducts);
        }

        public IActionResult Details(int? ID)
        {
            /* this controller will show details of a product
               ürünlerin detaylarını gösterir, ürün sayfası
             */

            if (ID == null)
            {
                // if there is no id data given, return not found
                return NotFound();
            }
            // else go fetch the product with the given id
            var theProduct = _productService.GetById((int)ID);
            // there might be NO PRODUCT with the given id
            if (theProduct == null)
            {
                // there is no such product
                return NotFound();
            }

            // in this case, product found and valid
            return View(theProduct);
        }
    }
}