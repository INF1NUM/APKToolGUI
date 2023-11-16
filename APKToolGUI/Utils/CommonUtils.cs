using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    internal static class CommonUtils
    {
        public static string GetApplicationNameFromManifest(string decompileFolder)
        {
            string[] Manifest = File.ReadAllLines(Path.Combine(decompileFolder, "AndroidManifest.xml"));
            foreach (string mf in Manifest)
            {
                if (mf.Contains("<application"))
                {
                    return StringExt.Regex(@"(?<=android:name=\"")(.*?)(?=\"")", mf);
                }
            }
            return "";
        }

        public static string GetActivityFromManifest(string decompileFolder)
        {
            string[] Manifest = File.ReadAllLines(Path.Combine(decompileFolder, "AndroidManifest.xml"));
            string packageName = "";
            string mainActivity = "";
            foreach (string mf in Manifest)
            {
                if (String.IsNullOrEmpty(packageName))
                    packageName = StringExt.Regex(@"(?<=package=\"")(.*?)(?=\"")", mf);

                if (mf.Contains("<activity"))
                {
                    mainActivity = StringExt.Regex(@"(?<=android:name=\"")(.*?)(?=\"")", mf);
                }
                if (mf.Contains("android.intent.action.MAIN"))
                {
                    if (mainActivity.StartsWith("."))
                        return packageName + mainActivity;
                }
            }
            return mainActivity;
        }

        public static bool OnCreateExists(string file)
        {
            if (File.Exists(file))
            {
                string text = File.ReadAllText(file);
                Match MyMatch = Regex.Match(text, ".*(method).*( onCreate).*");
                if (MyMatch.Success)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
