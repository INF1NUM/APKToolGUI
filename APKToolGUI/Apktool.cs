using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
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
            Null
        }
        static class DecompileKeys
        {
            public const string NoSource = " -s";
            public const string NoResource = " -r";
            public const string Force = " -f";
            public const string FrameworkPath = " -p";
            public const string KeepBrokenResource = " -k";
            public const string MatchOriginal = " -m";
            public const string OutputDir = " -o";
        }
        static class BuildKeys
        {
            public const string ForceAll = " -f";
            public const string CopyOriginal = " -c";
            public const string Aapt = " -a";
            public const string FrameworkPath = " -p";
            public const string OutputAppPath = " -o";
        }
        static class InstallFrameworkKeys
        {
            public const string FrameDir = " -p";
            public const string Tag = " -t";
        }
        ApktoolActionType lastActionType = ApktoolActionType.Null;
        string lastFilePath;
        string lastProjectDir;
        ApktoolDataReceivedEventHandler onApktoolOutputDataRecieved;
        ApktoolDataReceivedEventHandler onApktoolErrorDataRecieved;
        ApktoolEventCompletedEventHandler onBuildCompleted;
        ApktoolEventCompletedEventHandler onDecompilingCompleted;
        ApktoolEventCompletedEventHandler onInstallFrameworkCompleted;

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

        public event ApktoolEventCompletedEventHandler BuildCompleted
        {
            add
            {
                onBuildCompleted += value;
            }
            remove
            {
                onBuildCompleted -= value;
            }
        }
        public event ApktoolEventCompletedEventHandler DecompilingCompleted
        {
            add
            {
                onDecompilingCompleted += value;
            }
            remove
            {
                onDecompilingCompleted -= value;
            }
        }
        public event ApktoolEventCompletedEventHandler InstallFrameworkCompleted
        {
            add
            {
                onInstallFrameworkCompleted += value;
            }
            remove
            {
                onInstallFrameworkCompleted -= value;
            }
        }

        public Apktool(string javaPath, string jarPath) : base(javaPath, jarPath)
        {
            this.Exited += Apktool_Exited;
            this.OutputDataReceived += Apktool_OutputDataReceived;
            this.ErrorDataReceived += Apktool_ErrorDataReceived;
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
            this.CancelOutputRead();
            this.CancelErrorRead();
            switch (lastActionType)
            {
                case ApktoolActionType.Build:
                    if (onBuildCompleted != null)
                        onBuildCompleted(this, new ApktoolEventCompletedEventArgs(this.ExitCode, lastFilePath, lastProjectDir));
                    lastActionType = ApktoolActionType.Null;
                    break;
                case ApktoolActionType.Decompile:
                    if (onDecompilingCompleted != null)
                        onDecompilingCompleted(this, new ApktoolEventCompletedEventArgs(this.ExitCode, lastFilePath, lastProjectDir));
                    lastActionType = ApktoolActionType.Null;
                    break;
                case ApktoolActionType.InstallFramework:
                    if (onInstallFrameworkCompleted != null)
                        onInstallFrameworkCompleted(this, new ApktoolEventCompletedEventArgs(this.ExitCode, lastFilePath, lastProjectDir));
                    lastActionType = ApktoolActionType.Null;
                    break;
                case ApktoolActionType.Null:
                    break;
                default:
                    break;
            }
        }

        public bool Decompile(DecompileOptions options)
        {
            lastActionType = ApktoolActionType.Decompile;
            lastFilePath = options.AppPath;
            lastProjectDir = options.OutputDirectory;

            string keyNoSrc = null, keyNoRes = null, keyForce = null, keyFramePath = null, keyKeepBrokenRes = null, keyMatchOriginal = null, keyOutputDir = null;

            if (options.NoSource)
                keyNoSrc = DecompileKeys.NoSource;
            if (options.NoResource)
                keyNoRes = DecompileKeys.NoResource;
            if (options.Force)
                keyForce = DecompileKeys.Force;
            if (options.KeepBrokenResource)
                keyKeepBrokenRes = DecompileKeys.KeepBrokenResource;
            if (options.MatchOriginal)
                keyMatchOriginal = DecompileKeys.MatchOriginal;
            if (!String.IsNullOrWhiteSpace(options.FrameworkPath))
                keyFramePath = String.Format("{0} \"{1}\"", DecompileKeys.FrameworkPath, options.FrameworkPath);
            if (!String.IsNullOrWhiteSpace(options.OutputDirectory))
                keyOutputDir = String.Format("{0} \"{1}\"", DecompileKeys.OutputDir, options.OutputDirectory);

            //string args = String.Format("d{0}{1}{2}{3}{4}{5} -o \"{6}\" \"{7}\"", keyNoSrc, keyNoRes, keyForce, keyKeepBrokenRes, keyMatchOriginal, keyFramePath, options.ProjectDirectory, options.AppPath);
            string args = String.Format("d{0}{1}{2}{3}{4}{5}{6} \"{7}\"", keyNoSrc, keyNoRes, keyForce, keyKeepBrokenRes, keyMatchOriginal, keyFramePath, keyOutputDir, options.AppPath);

            bool started = this.Start(args);
            this.BeginOutputReadLine();
            this.BeginErrorReadLine();
            return started;
        }

        public bool Build(BuildOptions options)
        {
            lastActionType = ApktoolActionType.Build;
            lastFilePath = options.AppPath;
            lastProjectDir = options.ProjectDirectory;

            string keyForceAll = null, keyAapt = null, keyCopyOriginal = null, keyFramePath = null, keyOutputAppPath = null;
            if (options.ForceAll)
                keyForceAll = BuildKeys.ForceAll;
            if (options.CopyOriginal)
                keyCopyOriginal = BuildKeys.CopyOriginal;
            if (!String.IsNullOrEmpty(options.AaptPath))
                keyAapt = String.Format("{0} \"{1}\"", BuildKeys.Aapt, options.AaptPath);
            if (!String.IsNullOrEmpty(options.FrameworkPath))
                keyFramePath = String.Format("{0} \"{1}\"", BuildKeys.FrameworkPath, options.FrameworkPath);
            if (!String.IsNullOrWhiteSpace(options.AppPath))
                keyOutputAppPath = String.Format("{0} \"{1}\"", BuildKeys.OutputAppPath, options.AppPath);

            string args = String.Format("b{0}{1}{2}{3}{4} \"{5}\"", keyForceAll, keyAapt, keyCopyOriginal, keyFramePath, keyOutputAppPath, options.ProjectDirectory);

            bool started = this.Start(args);
            this.BeginOutputReadLine();
            this.BeginErrorReadLine();
            return started;
        }
        
        public bool InstallFramework(InstallFrameworkOptions options)
        {
            lastActionType = ApktoolActionType.InstallFramework;
            lastFilePath = options.InputFramePath;
            lastProjectDir = null;

            string keyFrameDir = null, keyTag = null;

            if (!String.IsNullOrWhiteSpace(options.FrameDir))
                keyFrameDir = String.Format("{0} \"{1}\"", InstallFrameworkKeys.FrameDir, options.FrameDir);
            if (!String.IsNullOrWhiteSpace(options.Tag))
                keyTag = String.Format("{0} \"{1}\"", InstallFrameworkKeys.Tag, options.Tag);

            string args = String.Format("if{0}{1} \"{2}\"", keyFrameDir, keyTag, options.InputFramePath);

            bool started = this.Start(args);
            this.BeginOutputReadLine();
            this.BeginErrorReadLine();
            return started;
        }

        public string GetVersion()
        {
            using (JarProcess apktoolJar = new JarProcess(this.JavaPath, this.JarPath))
            {
                apktoolJar.EnableRaisingEvents = false;
                apktoolJar.Start("-version");
                string version = apktoolJar.StandardOutput.ReadToEnd();
                apktoolJar.WaitForExit(3000);
                return version;
            }
        }

        private static ApktoolEventType GetEventType(string message)
        {
            MatchCollection mCol = Regex.Matches(message, @"^(\w+):\s(.+)$");
            if (mCol.Count > 0)
            {
                switch (mCol[0].Groups[1].Value)
                {
                    case "W":
                        return ApktoolEventType.Warning;
                    case "Warning":
                        return ApktoolEventType.Warning;
                    case "I":
                        return ApktoolEventType.Information;
                    case "Error":
                        return ApktoolEventType.Error;
                    case "E":
                        return ApktoolEventType.Error;
                    default:
                        return ApktoolEventType.Unknown;
                }
            }
            else
                return ApktoolEventType.Unknown;
        }
    }

    public delegate void ApktoolEventCompletedEventHandler(Object sender, ApktoolEventCompletedEventArgs e);

    public class ApktoolEventCompletedEventArgs : EventArgs
    {
        private int _exitCode;
        private string _filePath;
        private string _projectDir;

        public ApktoolEventCompletedEventArgs(int exitCode, string filePath, string projectDir)
        {
            _exitCode = exitCode;
            _filePath = filePath;
            _projectDir = projectDir;
        }

        public int ExitCode
        {
            get
            {
                return _exitCode;
            }
        }
        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }
        public string ProjectDir
        {
            get
            {
                return _projectDir;
            }
        }
    }

    public delegate void ApktoolDataReceivedEventHandler(Object sender, ApktoolDataReceivedEventArgs e);

    public class ApktoolDataReceivedEventArgs : EventArgs
    {
        string data;
        string message;
        ApktoolEventType eventType;

        public ApktoolDataReceivedEventArgs(string data)
        {
            this.data = data;
            SetData();
        }
        public String Message{
            get{
                return message;}}
        public ApktoolEventType EventType{
            get{
                return eventType;}}

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
                        eventType = ApktoolEventType.Information;
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
        Information,
        Warning,
        Error,
        Unknown
    }

    public class BuildOptions
    {
        public BuildOptions(string projectDir)
        {
            this.ProjectDirectory = projectDir;
        }
        //public BuildOptions(string projectDir, string apkPath)
        //{
        //    this.ProjectDirectory = projectDir;
        //    this.AppPath = apkPath;
        //}
        public string ProjectDirectory { get; set; }
        /// <summary>
        /// The name of apk that gets written.
        /// </summary>
        public string AppPath { get; set; }
        /// <summary>
        /// Loads aapt from specified location.
        /// </summary>
        public string AaptPath { get; set; }
        /// <summary>
        /// Skip changes detection and build all files.
        /// </summary>
        public bool ForceAll { get; set; }
        /// <summary>
        /// Copies original AndroidManifest.xml and META-INF.
        /// </summary>
        public bool CopyOriginal { get; set; }
        /// <summary>
        /// Uses framework files located in dir.
        /// </summary>
        public string FrameworkPath { get; set; }
    }

    public class DecompileOptions
    {
        public DecompileOptions(string apkPath)
        {
            this.AppPath = apkPath;
            this.OutputDirectory = String.Format("{0}\\{1}", System.IO.Path.GetDirectoryName(apkPath), System.IO.Path.GetFileNameWithoutExtension(apkPath));
        }
        /// <summary>
        /// The name of folder that gets written.
        /// </summary>
        public string OutputDirectory { get; set; }
        public string AppPath { get; set; }
        /// <summary>
        /// Do not decode sources.
        /// </summary>
        public bool NoSource { get; set; }
        /// <summary>
        /// Do not decode resources.
        /// </summary>
        public bool NoResource { get; set; }
        /// <summary>
        /// Force delete destination directory.
        /// </summary>
        public bool Force { get; set; }
        /// <summary>
        /// Uses framework files located in dir.
        /// </summary>
        public string FrameworkPath { get; set; }
        /// <summary>
        /// Use if there was an error and some resourceswere dropped, e.g."Invalid config flags detected. Dropping resources", 
        /// but you want to decode them anyway, even with errors. You will have to fix them manually before building.
        /// </summary>
        public bool KeepBrokenResource { get; set; }
        /// <summary>
        /// Keeps files to closest to original as possible. Prevents rebuild.
        /// </summary>
        public bool MatchOriginal { get; set; }
    }

    public class InstallFrameworkOptions
    {
        public InstallFrameworkOptions(string framePath)
        {
            this.InputFramePath = framePath;
        }
        public string InputFramePath { get; set; }
        /// <summary>
        /// Stores framework files into directory
        /// </summary>
        public string FrameDir { get; set; }
        /// <summary>
        /// Frameworks tag
        /// </summary>
        public string Tag { get; set; }
    }

    //public class ApktoolMessage
    //{
    //    public ApktoolEventType EventType { get; private set; }
    //    public string Message { get; private set; }
    //    private string data;

    //    public ApktoolMessage(string data)
    //    {
    //        this.data = data;
    //        SetData();
    //    }

    //    private void SetData()
    //    {
    //        MatchCollection mCol = Regex.Matches(data, @"^(\w+):\s(.+)$");
    //        if (mCol.Count > 0)
    //        {
    //            switch (mCol[0].Groups[1].Value)
    //            {
    //                case "W":
    //                    this.EventType = ApktoolEventType.Warning;
    //                    this.Message = mCol[0].Groups[2].Value;
    //                    break;
    //                case "Warning":
    //                    this.EventType = ApktoolEventType.Warning;
    //                    this.Message = mCol[0].Groups[2].Value;
    //                    break;
    //                case "I":
    //                    this.EventType = ApktoolEventType.Information;
    //                    this.Message = mCol[0].Groups[2].Value;
    //                    break;
    //                case "Error":
    //                    this.EventType = ApktoolEventType.Error;
    //                    this.Message = mCol[0].Groups[2].Value;
    //                    break;
    //                case "E":
    //                    this.EventType = ApktoolEventType.Error;
    //                    this.Message = mCol[0].Groups[2].Value;
    //                    break;
    //                default:
    //                    this.EventType = ApktoolEventType.Unknown;
    //                    this.Message = data;
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            this.EventType = ApktoolEventType.Unknown;
    //            this.Message = data;
    //        }
    //    }

    //    public static ApktoolEventType GetEventType(string data)
    //    {
    //        MatchCollection mCol = Regex.Matches(data, @"^(\w+):\s(.+)$");
    //        if (mCol.Count > 0)
    //        {
    //            switch (mCol[0].Groups[1].Value)
    //            {
    //                case "W":
    //                    return ApktoolEventType.Warning;
    //                case "Warning":
    //                    return ApktoolEventType.Warning;
    //                case "I":
    //                    return ApktoolEventType.Information;
    //                case "Error":
    //                    return ApktoolEventType.Error;
    //                case "E":
    //                    return ApktoolEventType.Error;
    //                default:
    //                    return ApktoolEventType.Unknown;
    //            }
    //        }
    //        else
    //            return ApktoolEventType.Unknown;
    //    }

    //    public static string GetMessage(string data)
    //    {
    //        MatchCollection mCol = Regex.Matches(data, @"^(\w+):\s(.+)$");
    //        if (mCol.Count > 0)
    //            return mCol[0].Groups[2].Value;
    //        else
    //            return data;
    //    }
    //}
}
