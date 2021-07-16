using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class ProductDetailsViewModel
    {
        /* this model will be used to render products and categories to the screen */

        public Product Product { get; set; }

        public List<Category> Categories { get; set; }
    }
}