using System;
using System.Collections.Generic;
using System.Text;

namespace SmartManagerServer.Core.Infrastructure.TypeExtensions
{
    public static class ExceptionExtension
    {
        public static string GetMessages(this Exception exception)
        {
            var messages = GetExceptionMessage(exception);
            return string.Join(Environment.NewLine, messages);
        }

        private static List<string> GetExceptionMessage(Exception exception, List<string> messages = null, int level = 0, int maxLevel = 5)
        {
            if (messages == null) messages = new List<string>();

            if (exception == null) return messages;
            messages.Add(exception.Message);
            if (level >= maxLevel) return messages;

            level++;

            return GetExceptionMessage(exception.InnerException, messages, level);
        }
    }
}
