using System;
using Java;
using System.Diagnostics;
using APKToolGUI.Properties;
using System.IO;
using APKToolGUI.Utils;
using System.Windows.Forms;

namespace APKToolGUI
{
    public class ApkEditor : JarProcess
    {
        public new event ApkEditorExitedEventHandler Exited;

        string _jarPath;
        public ApkEditor(string javaPath, string jarPath)
            : base(javaPath, jarPath)
        {
            this._jarPath = jarPath;
            base.Exited += ApkEditor_Exited;
            OutputDataReceived += ApkEditor_OutputDataReceived;
            ErrorDataReceived += ApkEditor_ErrorDataReceived; //Output makes process way slower
        }

        ApkEditorDataReceivedEventHandler onApkEditorOutputDataRecieved;
        ApkEditorDataReceivedEventHandler onApkEditorErrorDataRecieved;

        public event ApkEditorDataReceivedEventHandler ApkEditorOutputDataRecieved
        {
            add
            {
                onApkEditorOutputDataRecieved += value;
            }
            remove
            {
                onApkEditorOutputDataRecieved -= value;
            }
        }
        public event ApkEditorDataReceivedEventHandler ApkEditorErrorDataRecieved
        {
            add
            {
                onApkEditorErrorDataRecieved += value;
            }
            remove
            {
                onApkEditorErrorDataRecieved -= value;
            }
        }


        private void ApkEditor_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onApkEditorErrorDataRecieved != null && e.Data != null)
                onApkEditorErrorDataRecieved(this, new ApkEditorDataReceivedEventArgs(e.Data));
        }

        private void ApkEditor_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onApkEditorOutputDataRecieved != null && e.Data != null)
                onApkEditorOutputDataRecieved(this, new ApkEditorDataReceivedEventArgs(e.Data));
        }

        void ApkEditor_Exited(object sender, EventArgs e)
        {
            if (Exited != null)
                Exited(this, new ApkEditorExitedEventArgs(ExitCode));
        }
        public void Cancel()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("java"))
                {
                    if (process.Id == Id)
                    {
                        ProcessUtils.KillAllProcessesSpawnedBy((uint)Id);
                        process.Kill();
                    }
                }
            }
            catch { }
        }

        public int Merge(string input, string output)
        {
            string inputFile = String.Format("-i \"{0}\"", input);
            string keyOutputDir = String.Format("-o \"{0}\"", output);

            string args = String.Format("m {0} {1} -f", inputFile, keyOutputDir);

            Log.d("ApkEditor CMD: " + _jarPath + " " + args);

            Start(args);

            BeginOutputReadLine();
            BeginErrorReadLine();

            WaitForExit();

            CancelOutputRead();
            CancelErrorRead();
            return ExitCode;
        }

        public int Decompile(string input, string output)
        {
            string inputFile = String.Format("-i \"{0}\"", input);
            string keyOutputDir = String.Format("-o \"{0}\"", output);

            string args = String.Format("d {0} {1} -f", inputFile, keyOutputDir);

            Log.d("ApkEditor CMD: " + _jarPath + " " + args);

            Start(args);

            BeginOutputReadLine();
            BeginErrorReadLine();

            WaitForExit();

            CancelOutputRead();
            CancelErrorRead();
            return ExitCode;
        }

        public int Build(string input, string output)
        {
            string inputFile = String.Format("-i \"{0}\"", input);
            string keyOutputDir = String.Format("-o \"{0}\"", output);

            string args = String.Format("b {0} {1} -f", inputFile, keyOutputDir);

            Log.d("ApkEditor CMD: " + _jarPath + " " + args);

            Start(args);

            BeginOutputReadLine();
            BeginErrorReadLine();

            WaitForExit();

            CancelOutputRead();
            CancelErrorRead();
            return ExitCode;
        }
        public string GetVersion()
        {
            using (JarProcess jar = new JarProcess(JavaPath, JarPath))
            {
                jar.EnableRaisingEvents = false;
                jar.Start("-version");

                //APKEditor always print as errors as usual :)
                string version = jar.StandardOutput.ReadToEnd();
                version += jar.StandardError.ReadToEnd();
                jar.WaitForExit(3000);
                return version.Replace("\r\n", "");
            }
        }
    }

    public class ApkEditorExitedEventArgs : EventArgs
    {
        public ApkEditorExitedEventArgs(int exitCode)
        {
            ExitCode = exitCode;
        }

        public int ExitCode { get; private set; }
    }

    public delegate void ApkEditorExitedEventHandler(object sender, ApkEditorExitedEventArgs e);

    public delegate void ApkEditorDataReceivedEventHandler(Object sender, ApkEditorDataReceivedEventArgs e);

    public class ApkEditorDataReceivedEventArgs : EventArgs
    {
        string message;

        public ApkEditorDataReceivedEventArgs(string _data)
        {
            message = _data;
        }
        public String Message
        {
            get
            {
                return message;
            }
        }
    }
}
