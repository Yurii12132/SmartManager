using SmartManagerServer.Worker.Configuration;
using SmartManagerServer.Worker.Services;
using System;
using System.Threading.Tasks;

namespace SmartManagerServer.Worker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WorkerConfiguration.Build();

            await new WorkerService(args, WorkerConfiguration.ServiceProvider).RunAsync();
        }
    }
}
