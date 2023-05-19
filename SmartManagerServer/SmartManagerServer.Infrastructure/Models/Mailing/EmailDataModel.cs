using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Infrastructure.Models.Mailing
{
    public class EmailDataModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> ToEmails { get; set; }
        public List<string> CcEmails { get; set; }
        public List<string> AttachmentFileNames { get; set; }
    }
}
