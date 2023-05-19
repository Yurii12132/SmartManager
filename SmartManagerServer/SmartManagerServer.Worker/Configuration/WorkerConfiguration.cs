using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartManagerServer.EndPointExtensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SmartManagerServer.Worker.Configuration
{
    public static class WorkerConfiguration
    {
        public static ServiceProvider ServiceProvider
        {
            get;
            private set;
        }

        public static void Build()
        {
            var environmentName = Environment.GetEnvironmentVariable("DEV_ENVIRONMENT");

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            services.AddEndpointConfiguration(configuration);

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
