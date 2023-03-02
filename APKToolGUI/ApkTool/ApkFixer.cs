
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
                string maniFestText = File.ReadAllText(manifestPath);
                maniFestText = maniFestText.Replace("\\ ", "\\u003");
                maniFestText = maniFestText.Replace("android:isSplitRequired=\"true\"", "");
                maniFestText = maniFestText.Replace("android:extractNativeLibs=\"false\"", "");
                maniFestText = maniFestText.Replace("android:useEmbeddedDex=\"true\"", "");
                maniFestText = maniFestText.Replace("android:manageSpace=\"true\"", "");
                maniFestText = maniFestText.Replace("android:localeConfig=\"@xml/locales_config\"", "");
                maniFestText = maniFestText.Replace("<queries>\r\n        <intent>\r\n            <action android:name=\"android.intent.action.MAIN\"/>\r\n        </intent>\r\n    </queries>", "");
                maniFestText = maniFestText.Replace("<intent> ​ <action android:name=\"android.intent.action.MAIN\"/> ​ </intent>", "");
                maniFestText = maniFestText.Replace("STAMP_TYPE_DISTRIBUTION_APK", "STAMP_TYPE_STANDALONE_APK");

                File.WriteAllText(Path.Combine(path, "AndroidManifest.xml"), maniFestText);

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
