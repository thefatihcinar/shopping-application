using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
