using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EfCore;
using ShopApp.Entities;
using ShopApp.WebUI.Identity;
using ShopApp.WebUI.Middlewares;
using ShopApp.WebUI.ViewModels;
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
            /* Add Database Context For Identity */
            services.AddDbContext<ApplicationIdentityDbContext>( 
                options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            // this means that I want to use SQL Server
            // and use this connection string
            // and use this object for connection

            /* Add Identity Service Itself */
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
                .AddDefaultTokenProviders();
            // This means that We want an identity system
            // that has Users and User Roles
            // and use default token providers

            services.Configure<IdentityOptions>( options => {

                /* password options */
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = true;

                /* lockout options */
                options.Lockout.MaxFailedAccessAttempts = 7; // maximum number of trials before lockout
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // for how long it should be locked out
                options.Lockout.AllowedForNewUsers = true;

                /* email options */
                options.User.RequireUniqueEmail = true; // one email one account

                /* signin options */
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.AddControllersWithViews();

            services.AddAutoMapper(typeof(Startup)); /* Use AutoMapper */

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

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                /*
                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "{products}/{category?}",
                    defaults: new { controller = "shop", action = "list" }
                    );

                endpoints.MapControllerRoute(
                        name: "adminProducts",
                        pattern: "admin/products",
                        defaults: new { controller = "admin", action = "index"}
                    );
                endpoints.MapControllerRoute(
                        name: "adminProducts",
                        pattern: "admin/products/{id?}",
                        defaults: new { controller = "admin", action = "editproduct"}

                    );
                */
               
            });

        }
    }
}