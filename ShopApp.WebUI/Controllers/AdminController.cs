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
    [Route("admin")]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper; // AutoMapper
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("products")]
        public IActionResult Index(int page = 1)
        {
            /* fetch delete status here from tempdata */
            // this might be called after deleting something
            if(TempData["DeleteMessage"] != null)
            {
                ViewBag.DeleteMessage = TempData["DeleteMessage"].ToString();
            }
            // this might be called afeter adding something
            if(TempData["CreationMessage"] != null)
            {
                ViewBag.CreationMessage = TempData["CreationMessage"].ToString();
            }
            // this might be called afeter updating something
            if (TempData["UpdateMessage"] != null)
            {
                ViewBag.UpdateMessage = TempData["UpdateMessage"].ToString();
            }

            const int pageSize = 5; // only 5 products in admin page

            return View(new ProductListViewModel() {
                PaginationInformation = new PageInfo()
                {
                    TotalItems = _productService.GetAll().Count(),
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    CurrentCategory = null,
                    BaseLink = "/admin/products"
                },
                Products = _productService.GetProductsByCategoryByPage(null, page, pageSize)
            });
        }


        [HttpGet]
        [Route("products/add")]
        public IActionResult AddProduct()
        {
            /* render add new product form to the screen */

            return View();
        }

        [HttpPost]
        [Route("products/add")]
        public IActionResult AddProduct(ProductViewModel model)
        {
            /* add new product */
            Product product = _mapper.Map<Product>(model);

            _productService.Create(product);

            TempData["CreationMessage"] = "The product is created successfully.";

            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("products/{id?}")]
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
        [Route("/admin/products/{id}")]
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

            // bring it to UI
            TempData["UpdateMessage"] = "The product has been successfully updated. You can check it out.";

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            // get the product with the given id 
            var product = _productService.GetById(id);

            // there might be no product
            if(product == null)
            {
                return NotFound();
            }

            // delete the product
            _productService.Delete(product);

            TempData["DeleteMessage"] = "The product has been deleted successfully.";

            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("categories")]
        public IActionResult Categories(int page = 1)
        {
            /* renders all categories */

            /* fetch the last status here from tempdata */
            // this might be called after creating something
            if (TempData["CreationMessage"] != null)
            {
                ViewBag.CreationMessage = TempData["CreationMessage"];
            }
            // this might be called after deleting something
            if (TempData["DeleteMessage"] != null)
            {
                ViewBag.DeleteMessage = TempData["DeleteMessage"];
            }
            // this might be called after updating something
            if (TempData["UpdateMessage"] != null)
            {
                ViewBag.UpdateMessage = TempData["UpdateMessage"];
            }

            const int pageSize = 3;

            var viewModel = new CategoryListViewModel()
            {
                PaginationInformation = new PageInfo
                {
                    TotalItems = _categoryService.GetAll().Count(),
                    ItemsPerPage = pageSize,
                    CurrentPage = page,
                    CurrentCategory = null,
                    BaseLink = "/admin/categories"
                },
                Categories = _categoryService.GetCategoriesByPage(page, pageSize)
            };

            return View(viewModel);
        }

        [HttpGet]
        [Route("categories/add")]
        public IActionResult AddCategory()
        {
            /* renders new category page */

            return View();
        }

        [HttpPost]
        [Route("categories/add")]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            // Convert View Model into an actual category to add
            var newCategory = _mapper.Map<Category>(model);

            // Add it to the database
            _categoryService.Create(newCategory);

            // Send message to the UI, indicating that the category has been added properly
            TempData["CreationMessage"] = "New Category is successfully created.";

            return RedirectToAction("categories");
        }

        [HttpGet]
        [Route("categories/{id?}")]
        public IActionResult EditCategory(int? id, int page = 1)
        {
            /* render edit page with a given category id */

            // Go get the category with the given id
            // in order to render to the screen 

            if(id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetByIdIncludingProducts((int) id);

            // the category still might be nul
            if(category == null)
            {
                return NotFound();
            }

            const int pageSize = 2;

            // Create a View Model from Category
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            // also include products of a category manually with paginating
            categoryViewModel.Products = category.ProductCategories.Select(obj => obj.Product)
                                                 .Skip((page - 1) * pageSize).Take(pageSize).ToList();
            // Send pagination information to the UI
            categoryViewModel.PaginationInformation = new PageInfo
            {
                TotalItems = categoryViewModel.Products.Count(),
                ItemsPerPage = pageSize,
                CurrentPage = page,
                CurrentCategory = null, // must be null, because of pagination
                BaseLink = $"/admin/categories/{id}"
            };
            

            return View(categoryViewModel);
        }

        [HttpPost]
        [Route("categories/{id}")]
        public IActionResult EditCategory(CategoryViewModel model)
        {
            /* update this category */

            // Go find the category with a given id
            var old = _categoryService.GetById(model.Id);

            // there might be no category with this given id
            if(old == null)
            {
                return NotFound();
            }

            // create an actual object from view model
            var updated = _mapper.Map<Category>(model);

            // Update it 
            _categoryService.Update(updated);

            // Signal to the UI about the Update
            TempData["UpdateMessage"] = "The category has been successfully updated.";

            return RedirectToAction("categories");
        }

        [HttpPost]
        [Route("categories/delete")]
        public IActionResult DeleteCategory(int id)
        {
            // Go get the category with the given id
            var category = _categoryService.GetById(id);

            // there might be no category with the given id
            if(category == null)
            {
                return NotFound();
            }

            // Delete the category
            _categoryService.Delete(category);

            // Signal the UI about the deletion
            TempData["DeleteMessage"] = "The category has been successfully deleted.";

            return RedirectToAction("categories");
        }
    }
}
