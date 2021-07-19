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
    public class ProductManager : IProductService
    {
        /*
         * these are the concrete, real services product manager deliveres
        */

        // business layer is connected to the repository
        private IProductRepository _productRepository; // referans to the product repository interface

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            // by injecting the concrete repository,
            // set the repository
        }

        public int CountByCategory(string category)
        {
            /* this method will return total number of products in a category */
            return _productRepository.CountByCategory(category);
        }

        public void Create(Product entity)
        {
            _productRepository.Create(entity);
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

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        public List<Category> GetCategoriesofProduct(int id)
        {
            var product = this.GetProductByIdIncludingCategories(id); // go get the product

            // select categories of a product and return them all
            return product.ProductCategories.Select(obj => obj.Category).ToList();
        }
    }
}