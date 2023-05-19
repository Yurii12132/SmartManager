using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Validation
{
    public class ModelValidationResult
    {
        public ModelValidationResult(bool valid, string errorMessage)
        {
            this.Valid = valid;
            this.ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; private set; }
        public bool Valid { get; private set; }
    }
}
