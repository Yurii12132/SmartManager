using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Infrastructure.Models.Configuration
{
    public class ActiveDirectoryConfiguration
    {
        public string Domain { get; set; }
        public string Container { get; set; }
        public string LocalGroupContainer { get; set; }
        public string AdminGroup { get; set; }
        public string UserGroup { get; set; }
    }
}
