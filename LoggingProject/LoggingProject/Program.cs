using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
               .WriteTo.Debug(Serilog.Events.LogEventLevel.Information)
                .CreateLogger();
            Log.Information("Proje �al��t�r�ld�");
         
            #region
           
            //.........................veri taban�na kaydetme...................................................
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(configuration).CreateLogger();
            //  .WriteTo.MSSqlServer("Server=DESKTOP-FEC73RP;Database=DbSerilogDemo;integrated security=true", "Logs")
            //     .CreateLogger();

            //Log.Information("uyar� mesaj� kaydetme");
            //Log.ForContext("User", "Y�netici").Information("Sonu� Duyurusu");
            //Log.Error("error seviyesinde ki mesaj�n� yazabilirsiniz");
            //Log.Fatal("Fatal seviyesinde ki mesaj�n�z� yazabilirsiniz");
            #endregion

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
