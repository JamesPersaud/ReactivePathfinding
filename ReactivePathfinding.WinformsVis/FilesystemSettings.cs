using System;
using ReactivePathfinding.Core;
using System.IO;

namespace ReactivePathfinding.WinformsVis
{
    /// <summary>
    /// These are class variables rather than constants so that they could be reconfigured.
    /// </summary>
    public class FilesystemSettings
    {        
        public static string FILE_PATH_TEMPLATE = "AgentTemplates";
        public static string FILE_PATH_EXPERIMENT = "Experiments";
        public static string FILE_PATH_HEIGHTMAP = "Heightmaps";
        
        public static string FILE_EXTENSION_TEMPLATE = "tmpl";
        public static string FILE_EXTENSION_EXPERIMENT = "expr";
        public static string FILE_EXTENSION_HEIGHTMAP = "htmp";

        public static string PathSeparator = Path.DirectorySeparatorChar.ToString();
        public static string CurrentPath = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;        

        public static string GetFullPath(string dir, string name, string extension)
        {
            return CurrentPath + PathSeparator + dir + PathSeparator + name + "." + extension;
        }

        public static string GetFullPath(AgentTemplate t)
        {
            return GetFullPath(FILE_PATH_TEMPLATE, t.Filename, FILE_EXTENSION_TEMPLATE);
        }

        public static string GetFullPath(Heightmap h)
        {
            return GetFullPath(FILE_PATH_HEIGHTMAP, h.Filename, FILE_EXTENSION_HEIGHTMAP);
        }

        public static string GetFullPath(Experiment e)
        {
            return GetFullPath(FILE_PATH_EXPERIMENT, e.Filename, FILE_EXTENSION_EXPERIMENT);
        }
    }    
}
