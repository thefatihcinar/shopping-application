using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class ProductViewModel
    {
        /* this is a view model for Product entity */
        /* generally for front-end operations */

        public int Id { get; set; }

        [Required(ErrorMessage = "Name must be entered.")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "Product name must be at least 2 characters long, and must be shorter than 200 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description must be provided.")]
        [StringLength(maximumLength: 30000, MinimumLength = 10, ErrorMessage = "Product description must be at least 10 characters long.")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "An Image must be provided.")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Price must be provided.")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 10 cents and 1 million dollars")] // between 10 cents and 1 million
        public decimal Price { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}
