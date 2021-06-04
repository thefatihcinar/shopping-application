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
    }
}