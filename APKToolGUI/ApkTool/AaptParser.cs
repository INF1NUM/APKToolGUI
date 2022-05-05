using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    public class AaptParser
    {
        public string ApkFile;

        public string AppName;

        public string PackageName;

        public string VersionName;

        public string VersionCode;

        public string SdkVersion;

        public string TargetSdkVersion;

        public string LaunchableActivity;

        public string Permissions;

        public string Screens;

        public string Locales;

        public string Densities;

        public string PlayStoreLink;

        public string ApkComboLink;

        public string ApkPureLink;

        public string ApkAioLink;

        public string AppIcon = null;

        public bool Parse(string file)
        {
            bool result = true;

            string info = ParseApkInfo(file);
            if (!String.IsNullOrEmpty(info))
            {
                string[] lines = info.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None);

                foreach (string line in lines)
                {
                    switch (line.Split(':')[0])
                    {
                        case "package":
                            PackageName = StringExt.Regex(@"(?<=package: name=\')(.*?)(?=\')", line);
                            VersionName = StringExt.Regex(@"(?<=versionName=\')(.*?)(?=\')", line);
                            VersionCode = StringExt.Regex(@"(?<=versionCode=\')(.*?)(?=\')", line);
                            break;
                        case "uses-permission":
                            Permissions += StringExt.Regex(@"(?<=name=\')(.*?)(?=\')", line) + "\n";
                            break;
                        case "sdkVersion":
                            SdkVersion = SdkToAndroidVer(StringExt.Regex(@"(?<=sdkVersion:\')(.*?)(?=\')", line));
                            break;
                        case "targetSdkVersion":
                            TargetSdkVersion = SdkToAndroidVer(StringExt.Regex(@"(?<=targetSdkVersion:\')(.*?)(?=\')", line));
                            break;
                        case "application-label":
                            AppName = StringExt.Regex(@"(?<=application-label:\')(.*?)(?=\')", line);
                            break;
                        case "application":
                            AppIcon = GetIcon(file, StringExt.Regex(@"(?<=icon=\')(.*?)(?=\')", line));
                            break;
                        case "launchable-activity":
                            LaunchableActivity = StringExt.Regex(@"(?<=name=\')(.*?)(?=\')", line);
                            break;
                        case "supports-screens":
                            var screens = Regex.Matches(line.Split(':')[1], @"(?<= \')(.*?)(?=\')").Cast<Match>().Select(m => m.Value).ToList();
                            Screens = string.Join(", ", screens);
                            break;
                        case "locales":
                            var locales = Regex.Matches(line.Split(':')[1], @"(?<= \')(.*?)(?=\')").Cast<Match>().Select(m => m.Value).ToList();
                            Locales = string.Join(", ", locales);
                            break;
                        case "densities":
                            var densities = Regex.Matches(line.Split(':')[1], @"(?<= \')(.*?)(?=\')").Cast<Match>().Select(m => m.Value).ToList();
                            Densities = string.Join(", ", densities);
                            break;
                    }
                }

                ApkFile = file;
                PlayStoreLink = "https://play.google.com/store/apps/details?id=" + PackageName;
                ApkComboLink = "https://apkcombo.com/a/" + PackageName;
                ApkPureLink = "https://apkpure.com/a/" + PackageName;
                ApkAioLink = "https://apkaio.com/app/" + PackageName;

                result = true;
            }

            return result;
        }

        private string ParseApkInfo(string path)
        {
            //For some reason, aapt2 hangs, so we will only use aapt2 when aapt1 fails to read UTF-8 character
            string apkinfo = CMD.ProcessStartWithOutput(Program.AAPT_PATH, "dump badging \"" + path + "\"");
            if (String.IsNullOrEmpty(apkinfo))
            {
                string apkinfo2 = CMD.ProcessStartWithOutput(Program.AAPT2_PATH, "dump badging \"" + path + "\"");
                if (!String.IsNullOrEmpty(apkinfo2))
                {
                    return apkinfo2;
                }
                else
                    return "";
            }
            else
                return apkinfo;
        }

        string[] iconFolder = { "mipmap-xxxhdpi-v4", "mipmap-xxhdpi-v4", "mipmap-xhdpi-v4", "mipmap-hdpi-v4", "mipmap-mdpi-v4", "mipmap-xhdpi", "mipmap-hdpi", "drawable-xxxhdpi-v4", "drawable-xxhdpi-v4", "drawable-xhdpi-v4", "drawable-hdpi-v4", "drawable-mdpi-v4" };

        private string GetIcon(string apkPath, string iconPath)
        {
            iconPath = iconPath.Replace(".xml", ".png");

            if (iconPath.Contains("anydpi-v26"))
            {
                foreach (string folder in iconFolder)
                {
                    string icon = iconPath.Replace("mipmap-anydpi-v26", folder).Replace("drawable-anydpi-v26", folder);

                    if (ZipUtils.Exists(apkPath, icon))
                    {
                        Debug.WriteLine("Icon path " + icon);
                        return icon;
                    }
                }
                return iconPath.Replace("mipmap-anydpi-v26", "mipmap-xhdpi").Replace(".xml", ".png");
            }
            else
            {
                Debug.WriteLine("Icon path " + iconPath);
                return iconPath;
            }
        }

        public string SdkToAndroidVer(string sdk)
        {
            switch (sdk)
            {
                case "31":
                    return "31: Android 12.0";
                case "30":
                    return "30: Android 11.0";
                case "29":
                    return "29: Android 10.0";
                case "28":
                    return "28: Android 9.0 (Pie)";
                case "27":
                    return "27: Android 8.1 (Oreo MR1)";
                case "26":
                    return "26: Android 8.0 (Oreo)";
                case "25":
                    return "25: Android 7.1 (Nougat MR1)";
                case "24":
                    return "24: Android 7.0 (Nougat)";
                case "23":
                    return "23: Android 6.0 (Marshmallow)";
                case "22":
                    return "22: Android 5.1 (Lollipop MR1)";
                case "21":
                    return "21: Android 5.0 (Lollipop)";
                case "20":
                    return "20: Android 4.4W (KitKat Watch)";
                case "19":
                    return "19: Android 4.4 (KitKat)";
                case "18":
                    return "18: Android 4.3 (Jelly Bean MR2)";
                case "17":
                    return "17: Android 4.2 (Jelly Bean MR1)";
                case "16":
                    return "16: Android 4.1 (Jelly Bean)";
                case "15":
                    return "15: Android 4.0.3 (Ice Cream Sandwich MR1)";
                case "14":
                    return "14: Android 4.0 (Ice Cream Sandwich)";
                case "13":
                    return "13: Android 3.2 (Honeycomb MR2)";
                case "12":
                    return "12: Android 3.1 (Honeycomb MR1)";
                case "11":
                    return "11: Android 3.0 (Honeycomb)";
                case "10":
                    return "10: Android 2.3.3 Gingerbread MR1";
                case "9":
                    return "9: Android 2.3 (Gingerbread)";
                case "8":
                    return "8: Android 2.2 (Froyo)";
                case "7":
                    return "7: Android 2.1 (Eclair MR1)";
                case "6":
                    return "6: Android 2.0.1 (Eclair 0.1)";
                case "5":
                    return "5: Android 2.0 (Eclair)";
                case "4":
                    return "4: Android 1.6 (Donut)";
                case "3":
                    return "3: Android 1.5 (Cupcake)";
                case "2":
                    return "2: Android 1.1 (Base 1.1)";
                case "1":
                    return "1: Android 1.0 (Base)";
                default:
                    return sdk;
            }
        }
    }
}
