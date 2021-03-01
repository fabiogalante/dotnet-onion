using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Dotnet.Onion.Template.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string env = Environment.GetEnvironmentVariable("ENV") ?? "dev";

            CreateHostBuilder(args, env).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string env)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(
                        context.HostingEnvironment.ContentRootPath + $"/Config/appsettings-{env}.json",
                        false, false);
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
