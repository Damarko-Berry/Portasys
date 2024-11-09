using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Portasys.Binary_Serialization
{
    public static class SaveLoad
    {
        public static void Save<T>(T obj, string ProjectName, string Filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(Path.Combine(PortableEnviroment.GetFolder(SystemFolders.ProgramData), ProjectName, Filename), FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, obj);
            }
            Console.WriteLine("Object serialized successfully.");
        }

        public static T Load <T>(string ProjectName, string Filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(Path.Combine(PortableEnviroment.GetFolder(SystemFolders.ProgramData), ProjectName, Filename), FileMode.Open, FileAccess.Read))
            {
                var person = (T)formatter.Deserialize(stream);
                Console.WriteLine("Object deserialized successfully.");
                return person;
            }
        }


    }
}
