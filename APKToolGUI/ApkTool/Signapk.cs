using System;
using Java;
using System.Diagnostics;
using APKToolGUI.Properties;
using APKToolGUI.Utils;

namespace APKToolGUI
{
    public class Signapk : JarProcess
    {
        public new event SignapkExitedEventHandler Exited;

        private string lastSourceApk;
        private string lastOutApk;
        public bool silent;

        SignapkDataReceivedEventHandler onSignapkOutputDataRecieved;
        SignapkDataReceivedEventHandler onSignapkErrorDataRecieved;

        public event SignapkDataReceivedEventHandler SignapkOutputDataRecieved
        {
            add
            {
                onSignapkOutputDataRecieved += value;
            }
            remove
            {
                onSignapkOutputDataRecieved -= value;
            }
        }
        public event SignapkDataReceivedEventHandler SignapkErrorDataRecieved
        {
            add
            {
                onSignapkErrorDataRecieved += value;
            }
            remove
            {
                onSignapkErrorDataRecieved -= value;
            }
        }

        string _jarPath;
        public Signapk(string javaPath, string jarPath)
            : base(javaPath, jarPath)
        {
            _jarPath = jarPath;
            Exited += Signapk_Exited;
            OutputDataReceived += Signapk_OutputDataReceived;
            ErrorDataReceived += Signapk_ErrorDataReceived;
        }

        private void Signapk_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onSignapkErrorDataRecieved != null && e.Data != null)
                onSignapkErrorDataRecieved(this, new SignapkDataReceivedEventArgs(e.Data));
        }

        private void Signapk_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onSignapkOutputDataRecieved != null && e.Data != null)
                onSignapkOutputDataRecieved(this, new SignapkDataReceivedEventArgs(e.Data));
        }

        private void Signapk_Exited(object sender, EventArgs e)
        {
            if (Exited != null)
                Exited(this, new SignapkExitedEventArgs(base.ExitCode, lastSourceApk, lastOutApk));
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

        public int Sign(string input, string output)
        {
            lastSourceApk = input;
            lastOutApk = Settings.Default.Sign_OutputDir;

            //--key : pk file | --cert : pem
            string key = String.Format("--key \"{0}\" --cert \"{1}\"", Settings.Default.Sign_PrivateKey, Settings.Default.Sign_PublicKey);
            if (Settings.Default.Sign_UseKeystoreFile)
                key = String.Format("--ks \"{0}\" --ks-pass pass:{1}", Settings.Default.Sign_KeystoreFilePath, Settings.Default.Sign_KeystorePassword);

            string alias = String.Format("--ks-key-alias CERT");
            if (Settings.Default.Sign_SetAlias)
                alias = String.Format("--ks-key-alias {0}", Settings.Default.Sign_Alias);

            string outputDir = null;
            if (Settings.Default.Sign_UseOutputDir || !Settings.Default.Sign_OverwriteInputFile)
                outputDir = String.Format("--out \"{0}\"", output);

            string v1 = null;
            if (Settings.Default.Sign_Schemev1 == 1)
                v1 = "--v1-signing-enabled true";
            if (Settings.Default.Sign_Schemev1 == 2)
                v1 = "--v1-signing-enabled false";

            string v2 = null;
            if (Settings.Default.Sign_Schemev2 == 1)
                v2 = "--v2-signing-enabled true";
            if (Settings.Default.Sign_Schemev2 == 2)
                v2 = "--v2-signing-enabled false";

            string v3 = null;
            if (Settings.Default.Sign_Schemev3 == 1)
                v3 = "--v3-signing-enabled true";
            if (Settings.Default.Sign_Schemev3 == 2)
                v3 = "--v3-signing-enabled false";

            string v4 = null;
            if (Settings.Default.Sign_Schemev4 == 1)
                v4 = "--v4-signing-enabled true";
            if (Settings.Default.Sign_Schemev4 == 2)
                v4 = "--v4-signing-enabled false";

            string args = String.Format("sign {0} {1} {2} {3} {4} {5} {6} \"{7}\"", key, alias, v1, v2, v3, v4, outputDir, lastSourceApk);

            Log.v("Signapk CMD: " + _jarPath + " " + args);

            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            CancelOutputRead();
            CancelErrorRead();
            return ExitCode;
        }
    }

    public delegate void SignapkExitedEventHandler(object sender, SignapkExitedEventArgs e);

    public class SignapkExitedEventArgs : EventArgs
    {
        public SignapkExitedEventArgs(int exitCode, string sourceFilePath, string outFilePath)
        {
            ExitCode = exitCode;
            SourceFilePath = sourceFilePath;
            OutFilePath = outFilePath;
        }

        public int ExitCode { get; private set; }

        public string SourceFilePath { get; private set; }

        public string OutFilePath { get; private set; }
    }

    public delegate void SignapkDataReceivedEventHandler(Object sender, SignapkDataReceivedEventArgs e);

    public class SignapkDataReceivedEventArgs : EventArgs
    {
        string message;

        public SignapkDataReceivedEventArgs(string _data)
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
