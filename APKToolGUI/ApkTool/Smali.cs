using System;
using Java;
using System.Diagnostics;
using APKToolGUI.Properties;
using System.IO;

namespace APKToolGUI
{
    public class Smali : JarProcess
    {
        public new event SmaliExitedEventHandler Exited;

        public Smali(string javaPath, string jarPath)
            : base(javaPath, jarPath)
        {
            base.Exited += Smali_Exited;
        }

        SmaliDataReceivedEventHandler onSmaliOutputDataRecieved;
        SmaliDataReceivedEventHandler onSmaliErrorDataRecieved;

        public event SmaliDataReceivedEventHandler SmaliOutputDataRecieved
        {
            add
            {
                onSmaliOutputDataRecieved += value;
            }
            remove
            {
                onSmaliOutputDataRecieved -= value;
            }
        }
        public event SmaliDataReceivedEventHandler SmaliErrorDataRecieved
        {
            add
            {
                onSmaliErrorDataRecieved += value;
            }
            remove
            {
                onSmaliErrorDataRecieved -= value;
            }
        }


        private void Smali_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onSmaliErrorDataRecieved != null && e.Data != null)
                onSmaliErrorDataRecieved(this, new SmaliDataReceivedEventArgs(e.Data));
        }

        private void Smali_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (onSmaliOutputDataRecieved != null && e.Data != null)
                onSmaliOutputDataRecieved(this, new SmaliDataReceivedEventArgs(e.Data));
        }
        void Smali_Exited(object sender, EventArgs e)
        {
            if (Exited != null)
                Exited(this, new SmaliExitedEventArgs(ExitCode));
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

        public int Assemble(string input, string output)
        {
            string inputFile = String.Format("\"{0}\"", input);
            string keyOutputDir = String.Format("-o \"{0}\"", output);

            string args = String.Format("a {0} {1}", inputFile, keyOutputDir);
            Start(args);
            BeginOutputReadLine();
            BeginErrorReadLine();
            WaitForExit();
            CancelOutputRead();
            CancelErrorRead();
            return ExitCode;
        }
    }

    public class SmaliExitedEventArgs : EventArgs
    {
        public SmaliExitedEventArgs(int exitCode)
        {
            ExitCode = exitCode;
        }

        public int ExitCode { get; private set; }
    }

    public delegate void SmaliExitedEventHandler(object sender, SmaliExitedEventArgs e);

    public delegate void SmaliDataReceivedEventHandler(Object sender, SmaliDataReceivedEventArgs e);

    public class SmaliDataReceivedEventArgs : EventArgs
    {
        string message;

        public SmaliDataReceivedEventArgs(string _data)
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
