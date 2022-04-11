
using APKToolGUI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKToolGUI.ApkTool
{
    public class ApkFixer
    {
        public static bool FixAndroidManifest(string path)
        {
            string manifestPath = Path.Combine(path, "AndroidManifest.xml");
            if (File.Exists(manifestPath))
            {
                string text = File.ReadAllText(manifestPath);
                text = text.Replace("android:isSplitRequired=\"true\"", "");
                text = text.Replace("android:extractNativeLibs=\"false\"", "");
                text = text.Replace("android:useEmbeddedDex=\"true\"", "");
                File.WriteAllText(Path.Combine(path, "AndroidManifest.xml"), text);
                return true;
            }
            return false;
        }

        public static bool RemoveApkToolDummies(string path)
        {
            string resPath = Path.Combine(path, "res", "values");
            if (Directory.Exists(resPath))
            {
                DirectoryUtils.ReplaceinFilesRegex(resPath, "(.*(?:APKTOOL_DUMMY).*)", "");
                return true;
            }
            return false;
        }

        public static bool ChangeSdkTo29(string path)
        {
            string ymlPath = Path.Combine(path, "apktool.yml");
            if (File.Exists(ymlPath))
            {
                string[] Manifest = File.ReadAllLines(ymlPath);
                string yml = "";
                foreach (string s in Manifest)
                {
                    int sdk = 30;
                    int.TryParse(StringExt.Regex(@"(?<= targetSdkVersion: \')(.*?)(?=\')", s), out sdk);
                    if (sdk >= 30)
                    {
                        yml += "  targetSdkVersion: '29'\n";
                        return true;
                    }
                    yml += s + "\n";
                }
                File.WriteAllText(ymlPath, yml);
            }
            return false;
        }
    }
}
