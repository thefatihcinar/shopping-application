using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.Memory
{
    public class MemoryProductRepository : IProductRepository
    {
        public void Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = new List<Product>() { 
                new Product(){Id = 1, Name = "Samsung Galaxy S6", ImageURL = "1.jpg"},
                new Product(){Id = 2, Name = "Samsung Galaxy S7", ImageURL = "2.jpg"},
                new Product(){Id = 3, Name = "Samsung Galaxy S8", ImageURL = "3.jpg"},
                new Product(){Id = 4, Name = "Samsung Galaxsy S9", ImageURL = "4.jpg"},
            };

            return products;
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
