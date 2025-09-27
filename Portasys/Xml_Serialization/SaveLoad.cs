using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Portasys.Xml_Serialization
{
    public static class SaveLoad
    {
        public static void Save<T>(T obj, string path)
        {
            Directory.CreateDirectory(path);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var stream = new StreamWriter(path);
            serializer.Serialize(stream, obj);
            stream.Close();
        }

        public static T Load <T>(string Filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader sr = new StreamReader(Filename);
            var obj = (T)xmlSerializer.Deserialize(sr);
            sr.Close();
            return obj;
        }

        public static string ToXml<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        public static T FromXml<T>(string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringReader textReader = new StringReader(xmlString))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
    }
}
