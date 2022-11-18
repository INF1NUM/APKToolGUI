using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

using APKToolGUI.Properties;
using Java;

namespace APKToolGUI
{
    public class Apktool : JarProcess
    {
        enum ApktoolActionType
        {
            Decompile,
            Build,
            InstallFramework,
            ClearFramework,
            Null
        }

        //Note: I don't use some features and don't use any framework related since I make it simple for game modding purposes
        static class DecompileKeys
        {
            public const string NoSource = " -s"; //Do not decode sources.
            public const string NoResource = " -r"; //Do not decode resources.
            public const string NoDebugInfo = " -b"; //don't write out debug info (.local, .param, .line, etc.)
            public const string Force = " -f"; //Skip changes detection and build all files.
            public const string FrameworkPath = " -p"; //Uses framework files located in <dir>.
            public const string KeepBrokenResource = " -k"; //Use if there was an error and some resources were dropped
            public const string MatchOriginal = " -m"; //Keeps files to closest to original as possible. Prevents rebuild.
            public const string OutputDir = " -o"; //The name of folder that gets written. Default is apk.out
            public const string OnlyMainClasses = " -only-main-classes"; //Only disassemble the main dex classes (classes[0-9]*.dex) in the root.
            public const string ApiLevel = " -api"; //The numeric api-level of the file to generate, e.g. 14 for ICS.
        }

        static class BuildKeys
        {
            public const string ForceAll = " -f"; //Skip changes detection and build all files.
            public const string CopyOriginal = " -c"; //opies original AndroidManifest.xml and META-INF. See project page for more info.
            public const string Aapt = " -a"; //Loads aapt from specified location.
            public const string FrameworkPath = " -p"; //Uses framework files located in <dir>.
            public const string OutputAppPath = " -o"; // The name of apk that gets written. Default is dist/name.apk
            public const string NoCrunch = " -nc"; // Disable crunching of resource files during the build step.
            public const string ApiLevel = " -api"; //The numeric api-level of the file to generate, e.g. 14 for ICS.
            public const string UseAapt2 = " --use-aapt2"; //Upgrades apktool to use experimental aapt2 binary.
        }

        static class InstallFrameworkKeys
        {
            public const string FrameDir = " -p"; //Stores framework files into <dir>.
            public const string Tag = " -t"; //Tag frameworks using <tag>.
        }

        ApktoolDataReceivedEventHandler onApktoolOutputDataRecieved;
        ApktoolDataReceivedEventHandler onApktoolErrorDataRecieved;

        public event ApktoolDataReceivedEventHandler ApktoolOutputDataRecieved
        {
            add
            {
                onApktoolOutputDataRecieved += value;
            }
            remove
            {
                onApktoolOutputDataRecieved -= value;
            }
        }
        public event ApktoolDataReceivedEventHandler ApktoolErrorDataRecieved
        {
            add
            {
                onApktoolErrorDataRecieved += value;
            }
            remove
            {
                onApktoolErrorDataRecieved -= value;
            }
        }

        public Apktool(string javaPath, string jarPath) : base(javaPath, jarPath)
        {
            Exited += Apktool_Exited;
            OutputDataReceived += Apktool_OutputDataReceived;
            ErrorDataReceived += Apktool_ErrorDataReceived;
        }

        private void Apktool_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onApktoolErrorDataRecieved != null && e.Data != null)
                onApktoolErrorDataRecieved(this, new ApktoolDataReceivedEventArgs(e.Data));
        }

        private void Apktool_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onApktoolOutputDataRecieved != null && e.Data != null)
                onApktoolOutputDataRecieved(this, new ApktoolDataReceivedEventArgs(e.Data));
        }

        private void Apktool_Exited(object sender, EventArgs e)
        {
            CancelOutputRead();
            CancelErrorRead();
        }

        public int Decompile(string inputPath, string outputDir)
        {
            string keyNoSrc = null, keyNoRes = null, keyForce = null, keyFramePath = null, keyMatchOriginal = null, keyOutputDir = null, onlyMainClasses = null, noDebugInfo = null, keyKeepBrokenRes = null, apiLevel = null;

            if (Settings.Default.Decode_NoSrc)
                keyNoSrc = DecompileKeys.NoSource;
            if (Settings.Default.Decode_NoRes)
                keyNoRes = DecompileKeys.NoResource;
            if (Settings.Default.Decode_Force)
                keyForce = DecompileKeys.Force;
            if (Settings.Default.Decode_KeepBrokenRes)
                keyKeepBrokenRes = DecompileKeys.KeepBrokenResource;
            if (Settings.Default.Decode_MatchOriginal)
                keyMatchOriginal = DecompileKeys.MatchOriginal;
            if (Settings.Default.Decode_OnlyMainClasses)
                onlyMainClasses = DecompileKeys.OnlyMainClasses;
            if (Settings.Default.Decode_NoDebugInfo)
                noDebugInfo = DecompileKeys.NoDebugInfo;
            if (Settings.Default.Decode_UseFramework)
                keyFramePath = String.Format("{0} \"{1}\"", DecompileKeys.FrameworkPath, Settings.Default.Decode_FrameDir);
            if (Settings.Default.Decode_SetApiLevel)
                apiLevel = String.Format("{0} {1}", DecompileKeys.ApiLevel, Settings.Default.Decode_ApiLevel);
            keyOutputDir = String.Format("{0} \"{1}\"", DecompileKeys.OutputDir, outputDir);

            string args = String.Format($"d{keyNoSrc}{keyNoRes}{keyForce}{onlyMainClasses}{noDebugInfo}{keyMatchOriginal}{keyFramePath}{keyKeepBrokenRes}{apiLevel}{keyOutputDir} \"{inputPath}\"");

            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            return ExitCode;
        }

        public int Build(string inputFolder, string outputFile)
        {
            string keyForceAll = null, keyAapt = null, keyCopyOriginal = null, noCrunch = null, keyFramePath = null, keyOutputAppPath = null, apiLevel = null, useAapt2 = null;
            if (Settings.Default.Build_ForceAll)
                keyForceAll = BuildKeys.ForceAll;
            if (Settings.Default.Build_CopyOriginal)
                keyCopyOriginal = BuildKeys.CopyOriginal;
            if (Settings.Default.Build_NoCrunch)
                noCrunch = BuildKeys.NoCrunch;
            if (Settings.Default.Build_UseAapt)
                keyAapt = String.Format("{0} \"{1}\"", BuildKeys.Aapt, Settings.Default.Build_AaptPath);
            if (Settings.Default.Build_UseFramework)
                keyFramePath = String.Format("{0} \"{1}\"", BuildKeys.FrameworkPath, Settings.Default.Build_FrameDir);
            if (Settings.Default.Build_SetApiLevel)
                apiLevel = String.Format("{0} {1}", DecompileKeys.ApiLevel, Settings.Default.Build_ApiLevel);
            if (Settings.Default.Build_UseAapt2)
                useAapt2 = BuildKeys.UseAapt2;
            keyOutputAppPath = String.Format("{0} \"{1}\"", BuildKeys.OutputAppPath, outputFile);

            string args = String.Format($"b{keyForceAll}{keyAapt}{keyCopyOriginal}{noCrunch}{keyFramePath}{apiLevel}{useAapt2}{keyOutputAppPath} \"{inputFolder}\"");

            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            return ExitCode;
        }

        public int InstallFramework()
        {
            string inputPath = Settings.Default.InstallFramework_InputFramePath;
            string keyFrameDir = null, keyTag = null;

            if (Settings.Default.InstallFramework_UseFrameDir)
                keyFrameDir = String.Format("{0} \"{1}\"", InstallFrameworkKeys.FrameDir, Settings.Default.InstallFramework_FrameDir);
            if (Settings.Default.InstallFramework_UseTag)
                keyTag = String.Format("{0} \"{1}\"", InstallFrameworkKeys.Tag, Settings.Default.InstallFramework_Tag);

            string args = String.Format($"if{keyFrameDir}{keyTag} \"{inputPath}\"");

            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            return ExitCode;
        }

        public int ClearFramework()
        {
            string args = String.Format("empty-framework-dir --force");

            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            return ExitCode;
        }

        public string GetVersion()
        {
            using (JarProcess apktoolJar = new JarProcess(JavaPath, JarPath))
            {
                apktoolJar.EnableRaisingEvents = false;
                apktoolJar.Start("-version");
                string version = apktoolJar.StandardOutput.ReadToEnd();
                apktoolJar.WaitForExit(3000);
                return version.Replace("\r\n", "");
            }
        }
    }

    public delegate void ApktoolDataReceivedEventHandler(Object sender, ApktoolDataReceivedEventArgs e);

    public class ApktoolDataReceivedEventArgs : EventArgs
    {
        string data;
        string message;
        ApktoolEventType eventType;

        public ApktoolDataReceivedEventArgs(string _data)
        {
            data = _data;
            SetData();
        }
        public String Message
        {
            get
            {
                return message;
            }
        }
        public ApktoolEventType EventType
        {
            get
            {
                return eventType;
            }
        }

        private void SetData()
        {
            MatchCollection mCol = Regex.Matches(data, @"^(\w+):\s(.+)$");
            if (mCol.Count > 0)
            {
                switch (mCol[0].Groups[1].Value)
                {
                    case "W":
                        eventType = ApktoolEventType.Warning;
                        message = mCol[0].Groups[2].Value;
                        break;
                    case "Warning":
                        eventType = ApktoolEventType.Warning;
                        message = mCol[0].Groups[2].Value;
                        break;
                    case "I":
                        eventType = ApktoolEventType.None;
                        message = mCol[0].Groups[2].Value;
                        break;
                    case "Error":
                        eventType = ApktoolEventType.Error;
                        message = mCol[0].Groups[2].Value;
                        break;
                    case "E":
                        eventType = ApktoolEventType.Error;
                        message = mCol[0].Groups[2].Value;
                        break;
                    default:
                        eventType = ApktoolEventType.Unknown;
                        message = data;
                        break;
                }
            }
            else
            {
                eventType = ApktoolEventType.Unknown;
                message = data;
            }
        }
    }

    public enum ApktoolEventType
    {
        None,
        Done,
        Infomation,
        Warning,
        Error,
        Unknown
    }
}
