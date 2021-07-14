﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
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
        private readonly IProductService _productService; 

        public AdminController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ProductListViewModel() { 
                Products = _productService.GetAll() 
            });
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

            _productService.Create(product);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult EditProduct(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            // get the product
            var product = _productService.GetById((int) id);

            // there might be no product with this id
            if(product == null)
            {
                return NotFound();
            }

            // create view model for product from product
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            
            // render this product to the screen for editing
            return View(productViewModel);
        }

        [HttpPost]
        public IActionResult EditProduct(ProductViewModel model)
        {
            // Go get the product with this given id
            // we have made the id attribute hidden in the form
            Product theProduct = _productService.GetById(model.Id);

            // the entity might be null, or it might not exist
            if(theProduct == null)
            {
                return NotFound();
            }

            // Update this product, using the view model
            // First convert the view model to an actual model
            theProduct = _mapper.Map<Product>(model);

            _productService.Update(theProduct);

            return RedirectToAction("index");
        }
    }
}
