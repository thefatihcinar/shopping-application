using AutoMapper;
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
        private readonly ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
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

            TempData["CreationMessage"] = "The product is created successfully.";

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
        public IActionResult Categories()
        {
            /* renders all categories */

            var viewModel = new CategoryListViewModel()
            {
                Categories = _categoryService.GetAll()
            };
            return View(viewModel);
        }
    }
}
