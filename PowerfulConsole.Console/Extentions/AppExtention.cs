using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerfulConsole.Service.Extensions;
using Serilog;
using System;

namespace PowerfulConsole.ConsoleApp.Extentions
{
    /// <summary>
    /// Registers all the app dependencies.
    /// </summary>
    public static class AppExtention
    {
        public static IServiceCollection ConfigureProcessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAppServic(configuration);

            return services;
        }
        public static IServiceProvider GetServiceProvider(IConfiguration configuration, ILogger logger)
        {
            var services = new ServiceCollection();
            services.ConfigureProcessService(configuration);

            services.AddLogging(config => config.AddSerilog(logger));
            
            return services.BuildServiceProvider();
        }
    }
}
