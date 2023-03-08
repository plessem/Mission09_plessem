using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mission09_plessem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_plessem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public IConfiguration Configuration { get; set; }

        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookstoreContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookstoreDBConnection"]);

           });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //wwwroot folder
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //if we get a category and a page num
                endpoints.MapControllerRoute(
                    "typepage",
                    "{categoryType}/Page{pageNum}",
                    new { Controller = "Home", action = "Index" });

                //if we just have a page number
                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index" });

                //if we just get a category
                endpoints.MapControllerRoute(
                    "type",
                    "{categoryType}",
                    new {Controller = "Home", action ="Index", pageNum=1}); //assigning a page number if there isnt one

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
