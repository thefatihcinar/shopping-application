using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    /*
     * TypeEntity: this repository is about which entity
     * TypeContext: this is the type of the DB Context
     */
    public class EfCoreGenericRepository<TypeEntity, TypeContext> : IRepository<TypeEntity>
        where TypeEntity : class
        where TypeContext : DbContext, new()
    {
        public void Create(TypeEntity entity)
        {
            using (var context = new TypeContext())
            {
                context.Set<TypeEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TypeEntity entity)
        {
            using(var context = new TypeContext())
            {
                context.Set<TypeEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public IQueryable<TypeEntity> GetAll(Expression<Func<TypeEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TypeEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TypeEntity GetOne(Expression<Func<TypeEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
