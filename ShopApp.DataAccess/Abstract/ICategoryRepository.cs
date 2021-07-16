using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Abstract
{
    public interface ICategoryRepository: IRepository<Category>
    {
        List<Category> GetCategoriesByPage(int page, int pageSize);
        Category GetByIdIncludingProducts(int id);
    }
}
