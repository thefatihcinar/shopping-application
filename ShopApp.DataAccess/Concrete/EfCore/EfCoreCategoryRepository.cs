using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.DataAccess.Concrete.EfCore
{

    public class EfCoreCategoryRepository: EfCoreGenericRepository<Category,ShopContext>, ICategoryRepository 
    {
        public List<Category> GetCategoriesByPage(int page, int pageSize)
        {

            using(var context = new ShopContext())
            {
                var categories = context.Categories.AsQueryable(); // get all of them

                return categories.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }

        }
        
        public Category GetByIdIncludingProducts(int id)
        {
            using(var context = new ShopContext())
            {
                return context.Categories.Where(obj => obj.Id == id)
                    .Include(obj => obj.ProductCategories)
                    .ThenInclude(obj => obj.Product)
                    .FirstOrDefault();
                /* get all of the products of a category */
            }

          
        }
    }
}
