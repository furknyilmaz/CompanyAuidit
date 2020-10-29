using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyAuidit.Contexts;
using CompanyAuidit.Helpers;
using CompanyAuidit.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CompanyAuidit
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<UserService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<ItemTypeService>();
            services.AddScoped<UserItemService>();
            services.AddScoped<ItemService>();
            services.AddScoped<DropdownHelper>();
            services.AddControllersWithViews();

            services.AddDbContext<CompanyAuiditContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Remote")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                );
            });
        }
    }
}
