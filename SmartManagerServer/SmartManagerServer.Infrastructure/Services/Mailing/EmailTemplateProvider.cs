using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SmartManagerServer.Infrastructure.Services.Mailing
{
    internal static class EmailTemplateProvider
    {
        private static string GetTemplate(string templateName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"SmartManagerServer.Infrastructure.Files.EmailTemplates.{templateName}.html";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetExceptionTemplate()
        {
            return GetTemplate("ExceptionNotificationTemplate");
        }
    }
}
