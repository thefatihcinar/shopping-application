using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Entities;

namespace ShopApp.DataAccess.Abstract
{
    public interface IRepository<Type>
    {
        Type GetById(int id);
        /* get entity based on given id */

        Type GetOne(Expression<Func<Type, bool>> filter);
        /* get the first entity with a lambda expression */

        IQueryable<Type> GetAll(Expression<Func<Type, bool>> filter);
        /* get all entities with a lambda expression */

        void Create(Type entity);
        /* create an entity */

        void Delete(Type entity);
        /* delete an entity */

        void Update(Type entity);
        /* update an entity */


    }
}
