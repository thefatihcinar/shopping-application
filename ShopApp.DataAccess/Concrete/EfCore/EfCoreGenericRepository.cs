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

        public IEnumerable<TypeEntity> GetAll(Expression<Func<TypeEntity, bool>> filter = null)
        {
            /*
                if there is no expression given, return all expression by default
            */
            using (var context = new TypeContext())
            {
                if(filter == null)
                {
                    // if there is no filter, return all
                    return context.Set<TypeEntity>().ToList();
                }
                else
                {
                    // if there is a filter
                    return context.Set<TypeEntity>().Where(filter).ToList();
                }
            }

        }

        public TypeEntity GetById(int id)
        {
            // this method finds elements by given id
            using (var context = new TypeContext())
            {
                return context.Set<TypeEntity>().Find(id);
            }
        }

        public TypeEntity GetOne(Expression<Func<TypeEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeEntity entity)
        {
            // this method will update an existing entity
            using(var context = new TypeContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
