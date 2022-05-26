using DataAccessLayer_DAL;
using DataAccessLayer_DAL.Models;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Laptop_Store
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
            services.AddDbContext<LaptopStoreDbContext>(dbContextOptionBuilder =>
            dbContextOptionBuilder.UseSqlServer("Server=BSC-PG02TQPS\\SQLEXPRESS;Database=LaptopSell;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddScoped<IRepository<Laptop>, SqlLaptopsRepository>();
            services.AddRazorPages();

            services.AddScoped<IRepository<Customer>, SqlCustomersRepository>();
            services.AddScoped<IRepository<Orders>, SqlOrdersRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<LaptopStoreDbContext>()
       .AddDefaultTokenProviders();
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

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
