using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace demo10.Models
{
    public static class TodoUtilities
    {
        public static string GetExecutingPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public async static Task XmlSerializeToFileAsync<T>(string xmlPath, T data)
        {
            using (var writer = new StreamWriter(xmlPath, false, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));

                serializer.Serialize(writer, data);
                await writer.FlushAsync();
            }
        }

        public static T XmlDeserializedFromFile<T>(string xmlPath) where T : class
        {
            using (var reader = new StreamReader(xmlPath, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));

                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
