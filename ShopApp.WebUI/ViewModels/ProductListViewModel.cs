using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class ProductListViewModel
    {
        public PageInfo PaginationInformation { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}