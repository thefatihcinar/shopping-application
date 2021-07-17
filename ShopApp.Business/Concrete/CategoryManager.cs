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
        private ICategoryRepository _categoryRepository; // reference to the category repository

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository; // dependency
            // by injecting the concrete repository
        }

        public void Create(Category entity)
        {
            _categoryRepository.Create(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll().ToList();
        }

        public List<Category> GetCategoriesByPage(int page, int pageSize)
        {
            return _categoryRepository.GetCategoriesByPage(page, pageSize);
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public Category GetByIdIncludingProducts(int id)
        {
            return _categoryRepository.GetByIdIncludingProducts(id);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }

        public bool Uncategorize(int categoryId, int productId)
        {
            return _categoryRepository.Uncategorize(categoryId, productId);

        }
    }
}