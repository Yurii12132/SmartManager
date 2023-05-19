using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Validation
{
    public class ModelValidationError
    {
        public ModelValidationError(string message, string code = "")
        {
            Message = message;
            Code = code;
        }
        public string Message { get; private set; }
        public string Code { get; private set; }
    }
}
