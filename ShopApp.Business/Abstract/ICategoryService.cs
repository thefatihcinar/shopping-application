using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService
    {
        /*
         * these are the services that category service provides
         */

        List<Category> GetAll();

        List<Category> GetCategoriesByPage(int page, int pageSize);
        /* this will return categories based on the interval provided */
        /* i.e. pagination */

        Category GetById(int id);

        Category GetByIdIncludingProducts(int id);
        /* this service returns the desired category with
         * products object in it / included by it 
         * since EF Core do not load many to many relation by default */

        bool Uncategorize(int categoryId, int productId);
        /* this service uncategorizes a product */

        void Create(Category entity);

        void Update(Category entity);

        void Delete(Category entity);

    }
}
