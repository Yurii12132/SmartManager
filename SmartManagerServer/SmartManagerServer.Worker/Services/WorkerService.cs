using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Worker.Services
{
    public class WorkerService
    {
        private readonly string[] args;
        public WorkerService(string[] args, ServiceProvider serviceProvider)
        {
            this.args = args;
        }

        private bool CheckArg(string arg)
        {
            foreach (var item in args)
            {
                if (item.Equals(arg, StringComparison.InvariantCultureIgnoreCase)) return true;
            }
            return false;
        }

        public async Task RunAsync()
        {
            if (CheckArg("--app-arg") == true)
            {
                //run method
            };
        }
    }
}
