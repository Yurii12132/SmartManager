using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Exceptions
{
    public class ExceptionHandlerModel
    {
        public string Message { get; set; }
        public string Stack { get; set; }
        public string Path { get; set; }
    }
}
