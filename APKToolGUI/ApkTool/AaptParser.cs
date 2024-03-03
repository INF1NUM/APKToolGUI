using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace APKToolGUI.Utils
{
    public class AaptParser
    {
        public string ApkFile;

        public string RealApkFile;

        public string Armv7ApkFile;

        public string Arm64ApkFile;

        public string AppName;

        public string PackageName;

        public string VersionName;

        public string VersionCode;

        public string MinSdkVersionDetailed;

        public string TargetSdkVersionDetailed;

        public string MinSdkVersion;

        public string TargetSdkVersion;

        public string LaunchableActivity;

        public string Permissions;

        public string Screens;

        public string Locales;

        public string Densities;

        public string NativeCode;

        public string PlayStoreLink;

        public string ApkComboLink;

        public string ApkPureLink;

        public string ApkAioLink;

        public string ApkGkLink;

        public string ApkSupportLink;

        public string ApkSosLink;

        public string ApkMirrorLink;

        public string ApkDlLink;

        public string AppIcon;

        public string FullInfo;


        public bool Parse(string file)
        {
            bool result = true;

            string info = ParseApkInfo(file);

            FullInfo = info;

            if (!String.IsNullOrEmpty(info))
            {
                string[] lines = info.Split(
                    new string[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None);

                List<string> nativecode = new List<string> { };
                List<string> nativecode2 = new List<string> { };
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
                            MinSdkVersionDetailed = SdkToAndroidVer(StringExt.Regex(@"(?<=sdkVersion:\')(.*?)(?=\')", line));
                            MinSdkVersion = StringExt.Regex(@"(?<=sdkVersion:\')(.*?)(?=\')", line);
                            break;
                        case "targetSdkVersion":
                            TargetSdkVersionDetailed = SdkToAndroidVer(StringExt.Regex(@"(?<=targetSdkVersion:\')(.*?)(?=\')", line));
                            TargetSdkVersion = StringExt.Regex(@"(?<=targetSdkVersion:\')(.*?)(?=\')", line);
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
                        case "alt-native-code":
                            nativecode2 = Regex.Matches(line.Split(':')[1], @"(?<= \')(.*?)(?=\')").Cast<Match>().Select(m => m.Value).ToList();
                            break;
                        case "native-code":
                            nativecode = Regex.Matches(line.Split(':')[1], @"(?<= \')(.*?)(?=\')").Cast<Match>().Select(m => m.Value).ToList();
                            break;
                    }
                }
                List<string> combinedList = nativecode2.Concat(nativecode).ToList();
                NativeCode += string.Join(", ", combinedList);
                ApkFile = file;
                PlayStoreLink = "https://play.google.com/store/apps/details?id=" + PackageName;
                ApkComboLink = "https://apkcombo.com/a/" + PackageName;
                ApkPureLink = "https://apkpure.com/a/" + PackageName;
                ApkAioLink = "https://apkaio.com/app/" + PackageName;

                result = true;
            }
            else
                result = false;

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

        //https://apilevels.com/
        public string SdkToAndroidVer(string sdk)
        {
            switch (sdk)
            {
                case "35":
                    return sdk + ": Android 15";
                case "34":
                    return sdk + ": Android 14";
                case "33":
                    return sdk + ": Android 14";
                case "32":
                    return sdk + ": Android 12.0L";
                case "31":
                    return sdk + ": Android 12";
                case "30":
                    return sdk + ": Android 11";
                case "29":
                    return sdk + ": Android 10";
                case "28":
                    return sdk + ": Android 9 (Pie)";
                case "27":
                    return sdk + ": Android 8.1 (Oreo)";
                case "26":
                    return sdk + ": Android 8.0 (Oreo)";
                case "25":
                    return sdk + ": Android 7.1 (Nougat)";
                case "24":
                    return sdk + ": Android 7.0 (Nougat)";
                case "23":
                    return sdk + ": Android 6 (Marshmallow)";
                case "22":
                    return sdk + ": Android 5.1 (Lollipop)";
                case "21":
                    return sdk + ": Android 5.0 (Lollipop)";
                case "20":
                    return sdk + ": Android 4.4W (KitKat Watch)";
                case "19":
                    return sdk + ": Android 4.4 (KitKat)";
                case "18":
                    return sdk + ": Android 4.3 (Jelly Bean)";
                case "17":
                    return sdk + ": Android 4.2 (Jelly Bean)";
                case "16":
                    return sdk + ": Android 4.1 (Jelly Bean)";
                case "15":
                    return sdk + ": Android 4.0.3 (Ice Cream Sandwich)";
                case "14":
                    return sdk + ": Android 4.0 (Ice Cream Sandwich)";
                case "13":
                    return sdk + ": Android 3.2 (Honeycomb)";
                case "12":
                    return sdk + ": Android 3.1 (Honeycomb)";
                case "11":
                    return sdk + ": Android 3.0 (Honeycomb)";
                case "10":
                    return sdk + ": Android 2.3.3 Gingerbread";
                case "9":
                    return sdk + ": Android 2.3 (Gingerbread)";
                case "8":
                    return sdk + ": Android 2.2 (Froyo)";
                case "7":
                    return sdk + ": Android 2.1 (Eclair)";
                case "6":
                    return sdk + ": Android 2.0.1 (Eclair)";
                case "5":
                    return sdk + ": Android 2.0 (Eclair)";
                case "4":
                    return sdk + ": Android 1.6 (Donut)";
                case "3":
                    return sdk + ": Android 1.5 (Cupcake)";
                case "2":
                    return sdk + ": Android 1.1 (Base 1.1)";
                case "1":
                    return sdk + ": Android 1.0 (Base)";
                default:
                    return sdk;
            }
        }
    }
}
