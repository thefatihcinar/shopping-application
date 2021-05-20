using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        /*
         *  this class will be used to seed the database 
         *  in other words add test data to the DB through code
         */

        public static void Seed()
        {
            using(var context = new ShopContext())
            {
                // If there is no migration that is pending to be applied to db
                const int NO_MIGRATION = 0;
                if(context.Database.GetPendingMigrations().Count() == NO_MIGRATION)
                {
                    // if we have stabil db, add these data
                    if(context.Categories.Count() == 0)
                    {
                        // if there is no category data , add them
                        context.Categories.AddRange(testCategories); // add these
                    }

                    if(context.Products.Count() == 0)
                    {
                        // if there is no products data, add them
                        context.Products.AddRange(testProducts); // add these
                    }
                }
            }
        }

        private static Category[] testCategories =
        {
            new Category(){ Name = "Cell Phones" },
            new Category(){ Name = "Computers" },
        };

        private static Product[] testProducts =
        {
            new Product(){ Name = "Samsung S5", Price = 2000, ImageURL = "1.jpg"},
            new Product(){ Name = "Samsung S6", Price = 3000, ImageURL = "2.jpg"},
            new Product(){ Name = "Samsung S7", Price = 4000, ImageURL = "3.jpg"},
            new Product(){ Name = "Samsung S8", Price = 5000, ImageURL = "4.jpg"},
            new Product(){ Name = "Samsung S9", Price = 6000, ImageURL = "5.jpg"},
            new Product(){ Name = "iPhone 6", Price = 4000, ImageURL = "6.jpg"},
            new Product(){ Name = "iPhone 7", Price = 5000, ImageURL = "7.jpg"},
        };
    }
}
