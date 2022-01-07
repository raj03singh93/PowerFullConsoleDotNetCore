using Microsoft.Extensions.Logging;
using PowerfulConsole.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerfulConsole.Service.Implementation
{
    /// <inheritdoc/>
    public class ProjectProcessor : IProjectProcessor
    {
        private readonly ILogger<ProjectProcessor> logger;

        /// <summary>
        /// Initializes the object.
        /// </summary>
        /// <param name="logger"></param>
        public ProjectProcessor(ILogger<ProjectProcessor> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Process()
        {
            logger.LogDebug("Processing started....");
        }
    }
}
