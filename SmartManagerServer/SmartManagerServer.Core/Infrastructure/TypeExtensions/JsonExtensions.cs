
using SmartManagerServer.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SmartManagerServer.Core.Infrastructure.TypeExtensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this ExceptionHandlerModel model)
        {
            return JsonSerializer.Serialize(model);
        }
    }
}
