using Microsoft.Extensions.Logging;
using PowerfulConsole.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerfulConsole.Service.Implementation
{
    public class ProjectProcessor : IProjectProcessor
    {
        private readonly ILogger<ProjectProcessor> logger;

        public ProjectProcessor(ILogger<ProjectProcessor> logger)
        {
            this.logger = logger;
        }

        public void Process()
        {
            logger.LogDebug("Processing started....");
        }
    }
}
