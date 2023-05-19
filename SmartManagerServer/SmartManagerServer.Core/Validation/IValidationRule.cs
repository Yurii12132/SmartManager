using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Validation
{
    public interface IValidationRule
    {
        ModelValidationError ValidationError { get; }
        bool Validate();
    }
}
