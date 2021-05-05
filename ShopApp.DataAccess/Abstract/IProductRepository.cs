using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Product GetById(int id);
        /* get product based on given id */

        Product GetOne(Expression<Func<Product, bool>> filter);
        /* get the first product with a lambda expression */

        IQueryable<Product> GetAll(Expression<Func<Product, bool>> filter);
        /* get all products with a lambda expression */

        void Create(Product entity);
        /* create a product */

        void Delete(Product entity);
        /* delete a product */

        void Update(Product entity);
        /* update a product */


    }
}
