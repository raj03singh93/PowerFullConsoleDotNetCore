using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerfulConsole.Service.Implementation;
using PowerfulConsole.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerfulConsole.Service.Extensions
{
    /// <summary>
    /// A service layer extention.
    /// </summary>
    public static class ServiceExtention
    {
        /// <summary>
        /// Adds service layer dependencies
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="configuration">configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddAppServic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectProcessor, ProjectProcessor>();
            return services;
        }
    }
}
