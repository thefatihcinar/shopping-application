using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; }

        public PageInfo PaginationInformation { get; set; }
        
        public List<Category> Categories { get; set; }
    }
}