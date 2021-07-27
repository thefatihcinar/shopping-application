using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength:100, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 100 characters")]
        public string Name { get; set; }

        public PageInfo PaginationInformation { get; set; }

        public List<Product> Products { get; set; }
    }
}
