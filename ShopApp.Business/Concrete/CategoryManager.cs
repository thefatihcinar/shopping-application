using ShopApp.Business.Abstract;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        /*
         * these are the real, concrete services, category manager delievers
        */

        // business layer is connected to the repository
        private ICategoryRepository __categoryRepository; // reference to the category repository

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            __categoryRepository = categoryRepository; // dependency
            // by injecting the concrete repository
        }

        public void Create(Category entity)
        {
            __categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            __categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return __categoryRepository.GetAll().ToList();
        }

        public List<Category> GetCategoriesByPage(int page, int pageSize)
        {
            return __categoryRepository.GetCategoriesByPage(page, pageSize);
        }

        public Category GetById(int id)
        {
            return __categoryRepository.GetById(id);
        }

        public Category GetByIdIncludingProducts(int id)
        {
            return __categoryRepository.GetByIdIncludingProducts(id);
        }

        public void Update(Category entity)
        {
            __categoryRepository.Update(entity);
        }
    }
}