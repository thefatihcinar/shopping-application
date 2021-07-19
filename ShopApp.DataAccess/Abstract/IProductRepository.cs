using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProductDetails(int id);

        /* this method will return the details of a products,
         especially categories inside */

        List<Product> GetProductsByCategoryByPage(string? category, int page, int pageSize);

        /* this method will return the products of a given cateogry
           and pagination operations */

        int CountByCategory(string category);

        /* this method will calculate number of items in a category */

        Product GetProductByIdIncludingCategories(int id);
        /* this method will return a product with its categories loaded in it */

        bool Create(Product entity, int[] categoryIds);
        /* this method will create a new product with categories */
        bool Update(Product updatedProduct, int[] categoryIds);
        /* this method will update a product including its categories */
    }
}