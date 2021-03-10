using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonProject.Models;
using Microsoft.AspNetCore.Http;

namespace AmazonProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AmazonDbContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:AmazonProjectConnection"]);
            });
                                                    //name should be the same with the model
            services.AddScoped<IAmazonRepository, EFAmazonRepository>();
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();
            app.Use(async (context, next) => { context.Response.Headers.Add("X-Xss-   Protection", "1"); await next(); });
            //new pagination
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("page",
                    "Books/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute(
                 "pagination",
                 "/P{pageNum}",
                 new { Controller = "Home", action = "Index" });
                endpoints.MapDefaultControllerRoute();
               //new razor page service routing
                endpoints.MapRazorPages();
            });
            //!!!!!!
            SeedData.EnsurePopulated(app);

        }
    }
}
