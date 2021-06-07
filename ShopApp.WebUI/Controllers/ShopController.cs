using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // EX ROUTE: products/category?page=2
        [HttpGet]
        public IActionResult List(string category, int page = 1)
        {
            /* this controller is for listing all the products in the app */
            /* also makes pagination operations */

            const int pageSize = 3; /* number of elements in a page */

            /* return all the products to the rendering */
            var productListModel = new ProductListModel()
            {
                PaginationInformation = new PageInfo()
                {
                    TotalItems = _productService.CountByCategory(category),
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)
            };

            return View(productListModel);
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
            var theProduct = _productService.GetProductDetails((int)ID);
            // there might be NO PRODUCT with the given id
            if (theProduct == null)
            {
                // there is no such product
                return NotFound();
            }

            // in this case, product found and valid
            // return ProductDetailModel which includes categories

            return View(new ProductDetailsModel
            {
                Product = theProduct,
                Categories = theProduct.ProductCategories.Select(prop => prop.Category).ToList()
            });
        }
    }
}