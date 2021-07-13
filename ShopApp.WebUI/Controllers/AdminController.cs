using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Entities;
using ShopApp.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper; // AutoMapper

        public AdminController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            /* render add new product form to the screen */

            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {
            /* add new product */
            Product product = _mapper.Map<Product>(model);
            

        }
    }
}
