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

        List<Product> GetProductsByCategory(string category);

        /* this method will return the products of a given cateogry */
    }
}