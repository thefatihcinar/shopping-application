using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IProductService
    {
        /*
         * this is the services that product service offers
         * which operations can be done
         */
        List<Product> GetAll();

        Product GetById();

        void Create(Product entity);

        void Update(Product entity);

        void Delete(Product entity);

    }
}
