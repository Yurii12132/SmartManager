using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private const string baseMessage = "The object you trying to find not exists in the database.";
        public EntityNotFoundException() : base(baseMessage)
        { }

        public EntityNotFoundException(int id) : base($"{baseMessage} Object identifier {id}")
        { }

        public EntityNotFoundException(int id, string entityName) : base($"The {entityName} not found with ID {id}.")
        { }
    }
}
