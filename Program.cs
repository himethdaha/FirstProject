using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPage
{
    public class Program
    {
        /*This is what converts the application which starts as a console
         app into an ASP app from the point of 'Build().Run()'*/
        public static void Main(string[] args)
        {
            //Configuration done by
            /*CreateHostBuilder calls CreateDefaultBuilder on a static WebHost
             class*/
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            /*Controls how ASP deals with controllers, models, routes etc*/
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
