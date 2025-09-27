using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Portasys.Binary_Serialization
{
    public static class SaveLoad
    {
        public static void Save<T>(T obj, string path)
        {
            Directory.CreateDirectory(path);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, obj);
            }
            Console.WriteLine("Object serialized successfully.");
        }

        public static T Load <T>(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var person = (T)formatter.Deserialize(stream);
                Console.WriteLine("Object deserialized successfully.");
                return person;
            }
        }

        public static byte[] ToBinary<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, obj);
                return memoryStream.ToArray();
            }
        }

        public static T FromBinary<T>(byte[] binaryData)
        {
            using (MemoryStream memoryStream = new MemoryStream(binaryData))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(memoryStream);
            }
        }

    }
}
