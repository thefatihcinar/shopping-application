using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities
{
    public class ProductCategory
    {
        /* this table and class maps products with belonging categories */

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        /* productID and categoryID they are together PRIMARY KEYS */

        public Category Category { get; set; }
        
        public Product Product { get; set; }

    }
}
