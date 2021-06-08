using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.ViewModels
{
    public class ProductModel
    {
        /* this is a ViewModel for Product entity */
        /* generally for front-end operations */

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
    }
}
