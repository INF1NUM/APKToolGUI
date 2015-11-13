using System;
using Java;
using System.Diagnostics;

namespace APKToolGUI
{
    public class Signapk : JarProcess
    {
        public new event SignapkExitedEventHandler Exited;
        public string PublicKeyPath { get; set; }
        public string PrivateKeyPath { get; set; }
        private string lastSourceApk;
        private string lastOutApk;

        public Signapk(string javaPath, string jarPath)
            : base(javaPath, jarPath)
        {
            base.Exited += Signapk_Exited;
        }

        void Signapk_Exited(object sender, EventArgs e)
        {
            if (this.Exited != null)
                this.Exited(this, new SignapkExitedEventArgs(base.ExitCode, lastSourceApk, lastOutApk));
        }

        public bool Sign(string sourceApk, string outApk)
        {
            return Sign(PublicKeyPath, PrivateKeyPath, sourceApk, outApk);
        }

        public bool Sign(string publicKeyPath, string privateKeyPath, string sourceApk, string outApk)
        {
            lastSourceApk = sourceApk;
            lastOutApk = outApk;
            string args = String.Format("\"{0}\" \"{1}\" \"{2}\" \"{3}\"", publicKeyPath, privateKeyPath, sourceApk, outApk);
            return base.Start(args);
        }
    }

    public class SignapkExitedEventArgs : EventArgs
    {
        public SignapkExitedEventArgs(int exitCode, string sourceFilePath, string outFilePath)
        {
            this.ExitCode = exitCode;
            this.SourceFilePath = sourceFilePath;
            this.OutFilePath = outFilePath;
        }

        public int ExitCode { get; private set; }
        public string SourceFilePath { get; private set; }
        public string OutFilePath { get; private set; }
    }
    public delegate void SignapkExitedEventHandler(object sender, SignapkExitedEventArgs e);
}
