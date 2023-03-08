using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using omoore2_mission9.Models;

namespace omoore2_mission9
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
            });

            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("categorypage", "{bookCategory}/Page{pageNum}", new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("Paging", "Page{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute("category", "{bookCategory}", new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
