using System;
using Java;
using System.Diagnostics;
using APKToolGUI.Properties;
using System.IO;

namespace APKToolGUI
{
    public class Baksmali : JarProcess
    {
        public new event BaksmaliExitedEventHandler Exited;

        public Baksmali(string javaPath, string jarPath)
            : base(javaPath, jarPath)
        {
            base.Exited += Baksmali_Exited;
            OutputDataReceived += Baksmali_OutputDataReceived;
            ErrorDataReceived += Baksmali_ErrorDataReceived;
        }

        BaksmaliDataReceivedEventHandler onBaksmaliOutputDataRecieved;
        BaksmaliDataReceivedEventHandler onBaksmaliErrorDataRecieved;

        public event BaksmaliDataReceivedEventHandler BaksmaliOutputDataRecieved
        {
            add
            {
                onBaksmaliOutputDataRecieved += value;
            }
            remove
            {
                onBaksmaliOutputDataRecieved -= value;
            }
        }
        public event BaksmaliDataReceivedEventHandler BaksmaliErrorDataRecieved
        {
            add
            {
                onBaksmaliErrorDataRecieved += value;
            }
            remove
            {
                onBaksmaliErrorDataRecieved -= value;
            }
        }


        private void Baksmali_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onBaksmaliErrorDataRecieved != null && e.Data != null)
                onBaksmaliErrorDataRecieved(this, new BaksmaliDataReceivedEventArgs(e.Data));
        }

        private void Baksmali_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onBaksmaliOutputDataRecieved != null && e.Data != null)
                onBaksmaliOutputDataRecieved(this, new BaksmaliDataReceivedEventArgs(e.Data));
        }

        void Baksmali_Exited(object sender, EventArgs e)
        {
            if (Exited != null)
                Exited(this, new BaksmaliExitedEventArgs(ExitCode));
        }

        public void Cancel()
        {
            try
            {
                if (HasExited == false)
                {
                    Kill();
                }
            }
            catch { }
        }

        public int Disassemble(string input, string output)
        {
            string inputFile = String.Format("\"{0}\"", input);
            string keyOutputDir = String.Format("-o \"{0}\"", output);

            string args = String.Format("d {0} {1}", inputFile, keyOutputDir);
            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            CancelOutputRead();
            CancelErrorRead();
            return ExitCode;
        }
    }

    public class BaksmaliExitedEventArgs : EventArgs
    {
        public BaksmaliExitedEventArgs(int exitCode)
        {
            ExitCode = exitCode;
        }

        public int ExitCode { get; private set; }
    }

    public delegate void BaksmaliExitedEventHandler(object sender, BaksmaliExitedEventArgs e);

    public delegate void BaksmaliDataReceivedEventHandler(Object sender, BaksmaliDataReceivedEventArgs e);

    public class BaksmaliDataReceivedEventArgs : EventArgs
    {
        string message;

        public BaksmaliDataReceivedEventArgs(string _data)
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
