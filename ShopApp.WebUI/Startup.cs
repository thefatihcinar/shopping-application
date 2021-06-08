using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.WebUI.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            // dependency injection: use MemoryProductRepository whenever I call IProductRepository

            services.AddScoped<IProductService, ProductManager>();
            // dependency injection: use ProductManager whenever I call it IProductService

            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            // dependency injection: use EfCategoryRepository whenever I call ICategoryRepository

            services.AddScoped<ICategoryService, CategoryManager>();
            // dependency injection: use CategoryManager whenever I call it ICategoryService

            services.AddMvc();
            // USE MVC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            // this means wwwroot is served / public

            app.CustomStaticFiles();
            // use middleware to serve modules, custom static files

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "{products}/{category?}",
                    defaults: new { controller = "shop", action = "list" }
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}