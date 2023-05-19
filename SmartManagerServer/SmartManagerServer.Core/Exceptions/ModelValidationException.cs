using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Exceptions
{
    public class ModelValidationException : Exception
    {
        public ModelValidationException(string errorMessage) : base($"Validation error! {errorMessage}")
        {
        }
    }
}
