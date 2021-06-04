using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class Product
    {
        /* this is the model that we define Product */
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        /* this products belongs to which categories */
    }
}