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

        void Create(Category entity);

        void Update(Category entity);

        void Delete(Category entity);

    }
}
