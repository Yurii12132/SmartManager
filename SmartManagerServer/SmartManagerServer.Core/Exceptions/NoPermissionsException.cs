using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Exceptions
{
    public class NoPermissionsException : Exception
    {
        public NoPermissionsException() : base($"You have no permission to perform this action!")
        {
        }
    }
}
