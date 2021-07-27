using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IProductService: IValidator<Product>
    {
        /*
         * this is the services that product service offers
         * which operations can be done
         */

        List<Product> GetAll();

        Product GetById(int id);

        Product GetProductDetails(int id);

        List<Product> GetProductsByCategoryByPage(string? category, int page, int pageSize);

        Product GetProductByIdIncludingCategories(int id);
        /* this service provides a product object including 
         * its categories loaded
         */

        List<Category> GetCategoriesofProduct(int id);
        /* this servise provides categories of a product */

        bool Create(Product entity);

        bool Create(Product entity, int[] categoryIds);
        /* this will create a product with its categories given */

        bool Update(Product entity);

        void Delete(Product entity);

        int CountByCategory(string category);

        /* this method will return total number of products that belong to a category */

        bool Update(Product entity, int[] categoryIds);
        /* this method will provide functionality that updates a product and its categories */
    }
}