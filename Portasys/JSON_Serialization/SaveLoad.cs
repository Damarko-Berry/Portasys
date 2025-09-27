using Newtonsoft.Json;
using System.IO;


namespace Portasys.JSON_Serialization
{
    public static class SaveLoad
    {
        public static void Save<T>(T obj, string path)
        {
            // Ensure the project directory exists
            Directory.CreateDirectory(path);
            // Serialize the object to JSON

            string jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
            // Write the JSON string to a file
            File.WriteAllText(path, jsonString);
        }

        public static T Load<T>(string filePath)
        {
            // Read the JSON string from the file

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file was not found.", filePath);
            }
            string jsonString = File.ReadAllText(filePath);
            // Deserialize the JSON string back to an object
            T obj = JsonConvert.DeserializeObject<T>(jsonString);
            return obj;
        }

        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public static T FromJson<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
