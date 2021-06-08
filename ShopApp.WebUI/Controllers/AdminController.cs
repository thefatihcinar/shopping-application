using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("/admin/add-product")]
        public IActionResult AddProduct()
        {
            /* render add new product form to the screen */

            return View();
        }
    }
}
