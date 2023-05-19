using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Models.Configuration
{
    public class SmtpConfiguration
    {
        public int Port { get; set; }
        public string Host { get; set; }
        public string FromAddress { get; set; }
        public string FromDisplayName { get; set; }
    }
}
