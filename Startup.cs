using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RazorPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //The purpose of ConfigureServices is to Configure DI
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<ApplicationDbContext>(option => option.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //PipleLine describes how the application should response to Http Requests
        //PipleLine is composed of individual parts called middleware 
        //Order of adding Middleware is Important
        /*Core Piepline Steps
         1 - IIS - Requests from browser arrives first in a web server like IIS
         2 - dotnet runtime - IIS invokes dotnet runtime which then runs the clr and then looks for 
             an entry point in the app. It will find that in the Main method and executes it which
             start the internel web server
         3 - Kestrel - Internal light-weight serve capable of handling the request.
             The Main method and the Startup class will configure the app and the request would
             be routed from IIS to Kestrel and then it will be pushed to the app
         4 - Application
         5 - Middleware - Everything will be processed here and the generated response is routed
             back to kestrel which will route it back to the IIS*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
