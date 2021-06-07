using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class ProductListModel
    {
        public PageInfo PaginationInformation { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}