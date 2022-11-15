using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    static class Version
    {
        private static string versionString = "Version 0.427";
        public static string downloadLink = "https://github.com/mike19283/RainbowZ-Editor";
        public static bool badLink;
        private static string pasteLink = "https://pastebin.com/Mumr1Un7";
        private static string openLink = "";
        static List<string> changeLog;
        private static string programName = "RainbowZ Editor";
        private static string messageHeader;
        private static string message = "";
        private static bool currentVersion;

        private static void IsUpdateAvailable()
        {
            try
            {
                //throw new System.ArgumentException();

                // Get current version from my pastebin
                System.Net.WebClient wc = new System.Net.WebClient();
                byte[] raw = wc.DownloadData(pasteLink);

                // Parse the string
                String webData = System.Text.Encoding.UTF8.GetString(raw);



                currentVersion = !webData.Contains(versionString);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Trouble connecting to the internet. You may be running outdated software!", programName);
                badLink = true;
            }


        }

        public static void ManualCheck()
        {
            IsUpdateAvailable();
            if (!badLink)
            {
                if (currentVersion)
                {
                    WillUserUpdate();
                }
                else
                {
                    MessageBox.Show("You are running the current version!", programName);
                }

            }



        }

        public static void OnLoad()
        {

        }

        public static void WillUserUpdate()
        {
            // Does the user want to update now?
            if (MessageBox.Show("Your version is outdated. Update now?", programName, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //MessageBox.Show("Please contact RainbowSprinklez on discord (Rainbow #2405) for any updates");
                System.Diagnostics.Process.Start(downloadLink);
                //Application.Exit();
            }
            else
            {
                MessageBox.Show("Not recommended", programName);
            }
        }


        public static string GetVersion() => versionString;

    }
}
