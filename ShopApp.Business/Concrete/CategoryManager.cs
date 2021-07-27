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
    public class CategoryManager : ICategoryService, IValidator<Category>
    {
        /*
         * these are the real, concrete services, category manager delievers
        */

        // business layer is connected to the repository
        private ICategoryRepository _categoryRepository; // reference to the category repository

        public Dictionary<string, string> Error { get; set; }

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

        public bool Validate(Category entity)
        {
            // assume that the given entity is valid
            bool isValid = true;

            // now try to prove wtether it is valid or not

            // Criteria 1. Category Name
            if (String.IsNullOrEmpty(entity.Name))
            {
                Error.Add("NameError", "Category name cannot be empty.");

                isValid = false; // now it is not valid any more
                return isValid;
            }

            // Criteria 2. Category Name must be at least 2 characters long
            if(entity.Name.Length < 2)
            {
                Error.Add("NameError", "Category name must be at least 2 characters long.");

                isValid = false; // now it is not valid any more
                return isValid;
            }

            /* return the final result, it all the criteria have been met */
            return isValid;
        }
    }
}