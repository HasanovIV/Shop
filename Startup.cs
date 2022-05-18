using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;
using Shop.Interfaces;
using Shop.Mocks;
using Shop.Data;
using Shop.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Shop
{
    public class Startup
    {
        //private IConfigurationRoot _confString;
        //public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        //{
        //    _confString = new ConfigurationBinder().se
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IChairs, MockChairs>();
            //services.AddSingleton<IChairsCategory, MockChairsCategory>();

            //services.AddTransient<IChairs, MockChairs>();
            //services.AddTransient<IChairsCategory, MockChairsCategory>();

            services.AddTransient<IChairs, ChairRepository>();
            services.AddTransient<IChairsCategory, CategoryRepository>();

            services.AddDbContext<AppDBContent>(x => x.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=ShopDB; Trusted_Connection=true"));

            //services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseMvc(routes =>
               {
                   routes.MapRoute(name: "Default", template: "{controller=Chair}/{action=List}");
               });

            //app.UseMvcWithDefaultRoute();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute("default", "{controller=Chair}/{action=List}");
            //});

            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
