using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SmartManagerServer.Core.Infrastructure.Utilities
{
    public static class ObjectXmlSerializer
    {
        public static string ToString<T>(T model)
        {
            string xml = string.Empty;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                using (XmlWriter writer = XmlWriter.Create(stringWriter, settings))
                {
                    XmlSerializerNamespaces names = new XmlSerializerNamespaces();
                    names.Add("", "");

                    serializer.Serialize(writer, model, names);
                    xml = stringWriter.ToString();
                }
            }

            return xml;
        }
    }
}
