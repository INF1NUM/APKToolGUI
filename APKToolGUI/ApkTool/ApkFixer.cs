
using APKToolGUI.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                text = text.Replace("android:manageSpace=\"true\"", "");
                text = text.Replace("android:manageSpace=\"true\"", "");
                text = text.Replace("<queries>\r\n        <intent>\r\n            <action android:name=\"android.intent.action.MAIN\"/>\r\n        </intent>\r\n    </queries>", "");
                text = text.Replace("<intent> ​ <action android:name=\"android.intent.action.MAIN\"/> ​ </intent>", "");
                File.WriteAllText(Path.Combine(path, "AndroidManifest.xml"), text);
                text = text.Replace("STAMP_TYPE_DISTRIBUTION_APK", "STAMP_TYPE_STANDALONE_APK");
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
                string ymll = File.ReadAllText(ymlPath);

                int sdk = 30;
                int.TryParse(StringExt.Regex(@"(?<= targetSdkVersion: \')(.*?)(?=\')", ymll), out sdk);
                if (sdk >= 30)
                {
                    ymll = ymll.Replace("targetSdkVersion: '" + sdk + "'", "targetSdkVersion: '29'");
                    File.WriteAllText(ymlPath, ymll);
                    return true;
                }
            }
            return false;
        }
    }
}
