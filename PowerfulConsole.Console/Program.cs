using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PowerfulConsole.ConsoleApp.Extentions;
using PowerfulConsole.Service.Interface;
using Serilog;
using System;

namespace PowerfulConsole.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = GetConfiguration(args);
            Log.Logger = GetLogger(config);
            try
            {
                Log.Information("App Started");

                //Method 2 - Preparing service using Host
                var serviceProvider = CreateHost(args, config).Build().Services;

                // Method 1 - Preparing a service
                //var serviceProvider = AppExtention.GetServiceProvider(config, Log.Logger);

                var processService = (IProjectProcessor)serviceProvider.GetService(typeof(IProjectProcessor));
                processService.Process();

                Log.Information("App Stopped");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application crashed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            Console.WriteLine("Hello World!");
        }

        private static IHostBuilder CreateHost(string[] args, IConfiguration configuration)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.ConfigureProcessService(configuration);
                })
                .UseSerilog();
        }

        private static Serilog.ILogger GetLogger(IConfiguration config)
        {
            return new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .CreateLogger();
        }

        private static IConfiguration GetConfiguration(string[] args)
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional : false, reloadOnChange : true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPDOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }
    }
}
