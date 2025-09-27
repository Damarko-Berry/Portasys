using System;
using System.Collections.Generic;
using System.IO;

namespace Portasys
{
    public class FolderEnviroment
    {
        public string Root { get; set; } = string.Empty;
        public OSPlatform Platform { get; set; }
        FolderEnviroment()
        {
        }

        public FolderEnviroment(OSPlatform platform)
        {
            Platform = platform;
            Generate();
        }
        public string GetFolder(SystemFolder specialFolder)
        {
            if (Root == string.Empty)
            {
                Generate();
                Directory.SetCurrentDirectory(Root);
            }
            if (TemplatePaths == null)
            {
                PopulateTemplatePaths(Platform);
            }
            return Path.Combine(Root, TemplatePaths[specialFolder]);
        }
        public void Generate()
        {
            var rt = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                //use base directory of current disc in linux
                Root = (rt.Contains(@"/mnt/")) ? Directory.GetCurrentDirectory() : rt;

            }
            else
            {
                Root = (rt.Contains(@"C:\")) ? Directory.GetCurrentDirectory() : rt;
            }

            PopulateTemplatePaths(Platform);

            Directory.SetCurrentDirectory(Root);
            int o = Enum.GetNames(typeof(SystemFolder)).Length;
            for (int i = 0; i < o; i++)
            {
                Directory.CreateDirectory(Path.Combine(Root, TemplatePaths[(SystemFolder)i]));
            }


        }

        void PopulateTemplatePaths(OSPlatform platform = OSPlatform.Windows)
        {
            switch (Platform)
            {

                case OSPlatform.Windows:
                    TemplatePaths = new Dictionary<SystemFolder, string>()
                    {
                        { SystemFolder.Application, Path.Combine("AppData", "Roaming") },
                        { SystemFolder.Cache, Path.Combine("AppData", "Local", "Temp") },
                        { SystemFolder.Config, Path.Combine("AppData", "Roaming") },
                        { SystemFolder.Data, Path.Combine("AppData", "Roaming") },
                        { SystemFolder.Runtime, Path.Combine("AppData", "Local", "Temp") },
                        { SystemFolder.Logs, Path.Combine("AppData", "Local", "Logs") },
                        { SystemFolder.system, Path.Combine("Windows", "System32") },
                        { SystemFolder.CommonAppData, Path.Combine("ProgramData") },
                        { SystemFolder.LocalAppData, Path.Combine("AppData", "Local") },
                        { SystemFolder.ProgramData, Path.Combine("ProgramData") },
                        { SystemFolder.MyDocuments, Path.Combine("Documents") },
                        { SystemFolder.Temp, Path.GetTempPath() }
                    };
                    break;
                case OSPlatform.Linux:
                    TemplatePaths = new Dictionary<SystemFolder, string>()
                    {
                        { SystemFolder.Application, Path.Combine(".config") },
                        { SystemFolder.Cache, Path.Combine(".cache") },
                        { SystemFolder.Config, Path.Combine(".config") },
                        { SystemFolder.Data, Path.Combine(".local", "share") },
                        { SystemFolder.Runtime, Path.Combine(".local", "share", "runtime") },
                        { SystemFolder.Logs, Path.Combine(".local", "share", "logs") },
                        { SystemFolder.system, Path.Combine("usr", "bin") },
                        { SystemFolder.CommonAppData, Path.Combine("usr", "share") },
                        { SystemFolder.LocalAppData, Path.Combine(".local") },
                        { SystemFolder.ProgramData, Path.Combine("usr", "share") },
                        { SystemFolder.MyDocuments, Path.Combine("Documents") },
                        { SystemFolder.Temp, Path.GetTempPath() }
                    };
                    break;
                case OSPlatform.MacOS:
                    TemplatePaths = new Dictionary<SystemFolder, string>()
                    {
                        { SystemFolder.Application, Path.Combine("Library", "Application Support") },
                        { SystemFolder.Cache, Path.Combine("Library", "Caches") },
                        { SystemFolder.Config, Path.Combine("Library", "Preferences") },
                        { SystemFolder.Data, Path.Combine("Library", "Application Support") },
                        { SystemFolder.Runtime, Path.Combine("Library", "Application Support", "runtime") },
                        { SystemFolder.Logs, Path.Combine("Library", "Logs") },
                        { SystemFolder.system, Path.Combine("System") },
                        { SystemFolder.CommonAppData, Path.Combine("Library", "Application Support") },
                        { SystemFolder.LocalAppData, Path.Combine("Library") },
                        { SystemFolder.ProgramData, Path.Combine("Library", "Application Support") },
                        { SystemFolder.MyDocuments, Path.Combine("Documents") },
                        { SystemFolder.Temp, Path.GetTempPath() }
                    };
                    break;
            }
        }
        Dictionary<SystemFolder, string> TemplatePaths = null;
    }


}
