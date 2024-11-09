using System;
using System.IO;
namespace Portasys
{
    public static class PortableEnviroment
    {
        static string Root= string.Empty;
        public static string GetFolder(SystemFolders specialFolder)
        {
            if(Root == string.Empty) Generate();
            return Path.Combine(Root, "system", specialFolder.ToString());
        }
        public static void Generate()
        {
            var rt = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory());
            Root = (rt.Contains(@"C:\")) ? Directory.GetCurrentDirectory() : rt;
            var nms = Enum.GetNames(typeof(SystemFolders));
            for (int i = 0; i < nms.Length; i++)
            {
                Directory.CreateDirectory(Path.Combine(Root, "system", nms[i]));
            }
        }
    }
}
