using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Portasys.Xml_Serialization
{
    public static class SaveLoad
    {
        public static void Save<T>(T obj, string ProjectName, string Filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var stream = new StreamWriter(Path.Combine(PortableEnviroment.GetFolder(SystemFolders.ProgramData), ProjectName, Filename));
            serializer.Serialize(stream, obj);
            stream.Close();
        }

        public static T Load <T>(string ProjectName, string Filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StreamReader sr = new StreamReader(Path.Combine(PortableEnviroment.GetFolder(SystemFolders.ProgramData), ProjectName, Filename));
            var obj = (T)xmlSerializer.Deserialize(sr);
            sr.Close();
            return obj;
        }
    }
}
