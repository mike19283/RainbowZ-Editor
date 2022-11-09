using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    static class Version
    {
        private static string versionString = "Version 0.421";
        public static string downloadLink;
        public static bool difVersion;
        private static string pasteLink = "https://pastebin.com/Mumr1Un7";
        private static string openLink = "";
        static List<string> changeLog;
        private static string programName = "Rainbow Edit";
        private static string messageHeader;
        private static string message = "";

        private static void IsUpdateAvailable()
        {
        }

        public static void ManualCheck()
        {
        }

        public static void OnLoad()
        {
        }

        public static void WillUserUpdate()
        {

            
        }


        public static string GetVersion() => versionString;

    }
}
