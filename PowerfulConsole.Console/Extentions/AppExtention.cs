using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerfulConsole.Service.Implementation;
using PowerfulConsole.Service.Interface;
using Serilog;
using System;

namespace PowerfulConsole.ConsoleApp.Extentions
{
    public static class AppExtention
    {
        public static IServiceCollection ConfigureProcessService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectProcessor, ProjectProcessor>();

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
