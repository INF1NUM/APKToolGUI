using APKToolGUI.Properties;
using APKToolGUI.Utils;
using System;
using System.Diagnostics;
using System.IO;

namespace APKToolGUI
{
    public class Zipalign
    {
        Process processZipalign;
        static class Keys
        {
            public const string CheckOnly = " -c";
            public const string OverwriteOutputFile = " -f";
            public const string VerboseOut = " -v";
            public const string Recompress = " -z";
        }

        public event DataReceivedEventHandler OutputDataReceived
        {
            add { processZipalign.OutputDataReceived += value; }
            remove { processZipalign.OutputDataReceived -= value; }
        }
        public event DataReceivedEventHandler ErrorDataReceived
        {
            add { processZipalign.ErrorDataReceived += value; }
            remove { processZipalign.ErrorDataReceived -= value; }
        }
        public event EventHandler Exited;
        public int ExitCode { get { return processZipalign.ExitCode; } }

        public Zipalign(string zipalignFileName)
        {
            processZipalign = new Process();
            processZipalign.EnableRaisingEvents = true;
            processZipalign.StartInfo.FileName = zipalignFileName;
            processZipalign.StartInfo.UseShellExecute = false; //отключаем использование оболочки, чтобы можно было читать данные вывода
            processZipalign.StartInfo.RedirectStandardOutput = true; // разрешаем перенаправление данных вывода
            processZipalign.StartInfo.RedirectStandardError = true; // разрешаем перенаправление данных вывода
            processZipalign.StartInfo.CreateNoWindow = true; //запрещаем создавать окно для запускаемой программы
            processZipalign.Exited += processZipalign_Exited;
        }

        void processZipalign_Exited(object sender, EventArgs e)
        {
            processZipalign.CancelOutputRead();
            processZipalign.CancelErrorRead();
            if (this.Exited != null)
                Exited(this, new EventArgs());
        }

        public int Align(string input, string output)
        {
            string keyCheckOnly = null, keyVerbose = null, keyRecompress = null, keyOverwriteOutputFile = null, keyOutputFile = null;

            if (Settings.Default.Zipalign_Verbose)
                keyVerbose = Keys.VerboseOut;
            if (Settings.Default.Zipalign_CheckOnly)
            {
                keyCheckOnly = Keys.CheckOnly;
            }
            else
            {
                if (Settings.Default.Zipalign_Recompress)
                    keyRecompress = Keys.Recompress;
                if (Settings.Default.Zipalign_OverwriteOutputFile)
                {
                    keyOverwriteOutputFile = Keys.OverwriteOutputFile;
                }
                //if (Settings.Default.Zipalign_OverwriteOutputFile)
                keyOutputFile = String.Format(" \"{0}\"", PathUtils.GetDirectoryNameWithoutExtension(output) + "_align_temp.apk");
                //else
                //    keyOutputFile = String.Format(" \"{0}\"", output);
            }

            string args = String.Format("{0}{1}{2}{3} {4} \"{5}\" {6}", keyCheckOnly, keyOverwriteOutputFile, keyVerbose, keyRecompress, Settings.Default.Zipalign_AlignmentInBytes, input, keyOutputFile);

            Debug.WriteLine("Zipalign: " + args);

            processZipalign.StartInfo.Arguments = args;
            processZipalign.Start();
            processZipalign.BeginOutputReadLine();
            processZipalign.BeginErrorReadLine();
            processZipalign.WaitForExit();

            //if (!Settings.Default.Zipalign_CheckOnly && Settings.Default.Zipalign_OverwriteOutputFile)
            //{
            File.Delete(output);
            File.Move(PathUtils.GetDirectoryNameWithoutExtension(output) + "_align_temp.apk", output);
            //}

            return ExitCode;
        }
    }
}
