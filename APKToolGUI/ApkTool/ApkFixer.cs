
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
        public static bool FixAndroidManifest(string decompilePath)
        {
            string manifestPath = Path.Combine(decompilePath, "AndroidManifest.xml");
            if (File.Exists(manifestPath))
            {
                string maniFestText = File.ReadAllText(manifestPath);
                maniFestText = maniFestText.Replace("\\ ", "\\u003");
                maniFestText = maniFestText.Replace("android:isSplitRequired=\"true\"", "");
                maniFestText = maniFestText.Replace("android:extractNativeLibs=\"false\"", "");
                maniFestText = maniFestText.Replace("android:useEmbeddedDex=\"true\"", "");
                maniFestText = maniFestText.Replace("android:manageSpace=\"true\"", "");
                maniFestText = maniFestText.Replace("android:localeConfig=\"@xml/locales_config\"", "");
                maniFestText = maniFestText.Replace("STAMP_TYPE_DISTRIBUTION_APK", "STAMP_TYPE_STANDALONE_APK");

                File.WriteAllText(manifestPath, maniFestText);

                return true;
            }
            return false;
        }

        public static bool FixApktoolYml(string decompilePath)
        {
            string ymlPath = Path.Combine(decompilePath, "apktool.yml");
            if (File.Exists(ymlPath))
            {
                string yml = File.ReadAllText(ymlPath);
                yml = yml.Replace("sparseResources: true", "sparseResources: false");

                File.WriteAllText(ymlPath, yml);
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
    }
}
