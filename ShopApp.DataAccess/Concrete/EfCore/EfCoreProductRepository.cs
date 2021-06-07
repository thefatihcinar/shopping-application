using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public Product GetProductDetails(int id)
        {
            /* this method will return details of a product
             especially category information embedded using SQL commands */

            using (var context = new ShopContext())
            {
                // connect to the database
                return context.Products
                              .Where(product => product.Id == id) // filter rows by id
                              .Include(reach => reach.ProductCategories) // join products table with productscategories table
                              .ThenInclude(reach => reach.Category)
                              .FirstOrDefault();
            }
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize)
        {
            /*
             *  this method will return products with a given category
             *  and makes pagination operations with a given page size
             */

            // connect to the database and get all products and then filter
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                // we will perform queries on this

                // category string might be null or empty
                if (!String.IsNullOrEmpty(category))
                {
                    // if there is a valid category, return all

                    products = products.Include(entity => entity.ProductCategories)
                                        .ThenInclude(entity => entity.Category)
                                        .Where(
                                            item => item.ProductCategories.Any(item => item.Category.Name.ToLower() == category.ToLower()));
                }

                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}