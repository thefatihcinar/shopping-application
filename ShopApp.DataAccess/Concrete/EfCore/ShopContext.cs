using Microsoft.EntityFrameworkCore;
using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EfCore
{
    public class ShopContext : DbContext
    {
        /* Context for Shop Database*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // telling to use SQL Server
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ShopDb; integrated security=true;");
            // This is the CONNECTION STRING
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                        .HasKey(anItem => new { anItem.CategoryId, anItem.ProductId});
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
