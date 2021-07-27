using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class ProductManager : IProductService, IValidator<Product>
    {
        /*
         * these are the concrete, real services product manager deliveres
        */

        // business layer is connected to the repository
        private IProductRepository _productRepository; // referans to the product repository interface

        public Dictionary<string, string> Error { get; set; }

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            // by injecting the concrete repository,
            // set the repository

            Error = new Dictionary<string, string>();
        }

        public int CountByCategory(string category)
        {
            /* this method will return total number of products in a category */
            return _productRepository.CountByCategory(category);
        }

        public bool Create(Product entity)
        {
            bool isValid = Validate(entity);

            if (isValid){
                // if the model is valid
                // add to the
                _productRepository.Create(entity);
                return true;
            }
            else
            {
                return false;
            }


        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Product GetProductDetails(int id)
        {
            return _productRepository.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategoryByPage(string? category, int page, int pageSize)
        {
            return _productRepository.GetProductsByCategoryByPage(category, page, pageSize);
        }

        public Product GetProductByIdIncludingCategories(int id)
        {
            return _productRepository.GetProductByIdIncludingCategories(id);
        }

        public bool Update(Product entity)
        {
            bool isValid = Validate(entity);

            if (isValid){

                _productRepository.Update(entity);
                return true;
            }
            else{

                return false;
            }
            
        }

        public List<Category> GetCategoriesofProduct(int id)
        {
            var product = this.GetProductByIdIncludingCategories(id); // go get the product

            // select categories of a product and return them all
            return product.ProductCategories.Select(obj => obj.Category).ToList();
        }

        public bool Update(Product entity, int[] categoryIds)
        {
            bool isValid = Validate(entity);

            if (isValid){
                // if the model is valid, allow update
                return _productRepository.Update(entity, categoryIds);
            }
            else{

                return false;
            }
            
        }

        public bool Create(Product entity, int[] categoryIds)
        {
            bool isValid = Validate(entity);

            if (isValid){
                // if the model is valid, allow add
                return _productRepository.Create(entity, categoryIds);
            }
            else{

                return false;
            }

            
        }

        public bool Validate(Product entity)
        {
            /* this method will validate a given product */

            bool isValid = true;


            // Criteria 1: Product name must exist. Cannot be null or empty
            if (String.IsNullOrEmpty(entity.Name)){

                Error.Add("NameError", "Product name must be provided, cannot be null or empty.");

                isValid = false;
                return isValid;
            }

            // Criteria 2: Product name must be at least 2, at most 200 characters long
            if(entity.Name.Length < 2 || entity.Name.Length > 200) {

                Error.Add("NameError", 
                    "Product name must be at least 2 characters, at most 200 characters long.");

                isValid = false;
                return isValid;

            }

            // Criteria 3: Description must exist. Cannot be null or empty
            if (String.IsNullOrEmpty(entity.Description))
            {
                Error.Add("DescriptionError", "Product description must be provided. Cannot be empty or null.");

                isValid = false;
                return isValid;
            }

            // Criteria 4: Description must be at least 10, at most 30 000 characters long
            if (entity.Description.Length < 10 || entity.Description.Length > 30000)
            {

                Error.Add("DescriptionError", 
                    "Description must be at least 10, at most 30 000 characters long");

                isValid = false;
                return isValid;

            }

            // Criteria 5: ImageURL must exist.
            if (String.IsNullOrEmpty(entity.ImageURL))
            {
                Error.Add("ImageURLError", "ImageURL must exist. Cannot be null or empty.");

                isValid = false;
                return isValid;

            }

            // Criteria 6: Price must be between 10 cents and 1 million dollars
            if(entity.Price <= (decimal) 0.01 || entity.Price >= 1000000)
            {
                Error.Add("PriceError", "Price must be between 10 cents and 1 million dollars");

                isValid = false;
                return isValid;
            }

            /* return the result of the validation */
            return isValid;
        }
    }
}