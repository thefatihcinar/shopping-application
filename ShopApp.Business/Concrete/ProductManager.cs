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
        private IProductRepository __productRepository; // referans to the product repository interface

        public ProductManager(IProductRepository productRepository)
        {
            __productRepository = productRepository;
            // by injecting the concrete repository,
            // set the repository
        }

        public int CountByCategory(string category)
        {
            /* this method will return total number of products in a category */
            return __productRepository.CountByCategory(category);
        }

        public void Create(Product entity)
        {
            __productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            __productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return __productRepository.GetAll().ToList();
        }

        public Product GetById(int id)
        {
            return __productRepository.GetById(id);
        }

        public Product GetProductDetails(int id)
        {
            return __productRepository.GetProductDetails(id);
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            return __productRepository.GetProductsByCategory(category, page, pageSize);
        }

        public void Update(Product entity)
        {
            __productRepository.Update(entity);
        }
    }
}