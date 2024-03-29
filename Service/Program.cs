using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               
                .ConfigureWebHostDefaults(webBuilder =>
                /*  webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var connectionString = config.Build().GetConnectionString("AppConfig");
                    config.AddAzureAppConfiguration(connectionString);
                })  */
                   webBuilder.UseStartup<Startup>());
    }
}