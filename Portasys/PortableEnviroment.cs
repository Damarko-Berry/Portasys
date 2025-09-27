using Newtonsoft.Json;
using System;
using System.IO;
namespace Portasys
{
    public static class PortableEnviroment
    {
        public static FolderEnviroment Enviroment = null;
        public static string Root => Enviroment.Root;
        public static OSPlatform GetCurrentPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Win32NT:
                    return OSPlatform.Windows;
                case PlatformID.Unix:
                    // MacOSX is also Unix, so we need to check for that
                    if (Directory.Exists("/Applications") && Directory.Exists("/System") && Directory.Exists("/Users") && Directory.Exists("/Volumes"))
                    {
                        return OSPlatform.MacOS;
                    }
                    else
                    {
                        return OSPlatform.Linux;
                    }
                case PlatformID.MacOSX:
                    return OSPlatform.MacOS;
                default:
                    return OSPlatform.Unknown;
            }
        }
        public static void FindRootFile()
        {
            var currentDir = Directory.GetCurrentDirectory();
            while (true)
            {
                if (File.Exists(Path.Combine(currentDir, "root.json")))
                {
                    //Find the OSplatform type in the json file
                    var json = File.ReadAllText(Path.Combine(currentDir, "root.json"));
                    var rootInfo = JsonConvert.DeserializeObject<FolderEnviroment>(json);
                    Initialize(rootInfo.Platform);
                    break;
                }
                try
                {
                    var parentDir = Directory.GetParent(currentDir);
                    if (parentDir == null)
                    {
                        break;
                    }
                    currentDir = parentDir.FullName;
                }
                catch
                {
                    break;
                }
            }
        }
        public static void Initialize()
        {
            FindRootFile();
            if (Enviroment == null)
            {
                var P = GetCurrentPlatform();
                Initialize(P);
            }
            else
            {
                Enviroment.Generate();
            }
            Directory.SetCurrentDirectory(Enviroment.Root);
        }
        public static void Initialize(FolderEnviroment folderEnviroment)
        {
            Enviroment = folderEnviroment;
            Enviroment.Generate();
        }
        public static void Initialize(OSPlatform platform = OSPlatform.Windows)
        {
            FindRootFile();
            if (Enviroment == null)
            {
                Enviroment = new FolderEnviroment(platform);
            }
            else
            {
                Enviroment.Generate();
            }
        }
        public static string GetFolder(SystemFolder specialFolder)
        {
            if (Enviroment == null)
            {
                Initialize();
            }
            return Enviroment.GetFolder(specialFolder);
        }

    }
}
