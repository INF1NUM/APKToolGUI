using System;
using System.Diagnostics;

namespace APKToolGUI
{
    public class Zipalign
    {
        string _zipalignPath;
        Process processZipalign;
        static class Keys
        {
            public const string CheckOnly = " -c";
            public const string OverwriteOutputFile = " -f";
            public const string VerboseOut = " -v";
            public const string Recompress = " -z";
        }

        public ZipalignOptions Options { get; set; }
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
            _zipalignPath = zipalignFileName;
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

        public bool Align(ZipalignOptions options)
        {
            this.Options = options;
            string keyCheckOnly = null, keyVerbose = null, keyRecompress = null, keyOverwriteOutputFile = null, keyOutputFile = null;

            if (options.VerboseOut)
                keyVerbose = Keys.VerboseOut;
            if (options.CheckOnly)
            {
                keyCheckOnly = Keys.CheckOnly;
            }
            else
            {
                if(options.Recompress)
                    keyRecompress = Keys.Recompress;
                if (options.OverwriteOutputFile)
                    keyOverwriteOutputFile = Keys.OverwriteOutputFile;
                keyOutputFile = String.Format(" \"{0}\"", options.OutputFile);
            }

            string args = String.Format("{0}{1}{2}{3} {4} \"{5}\"{6}", keyCheckOnly, keyOverwriteOutputFile, keyVerbose, keyRecompress, options.AlignmentInBytes, options.InputFile, keyOutputFile);

            processZipalign.StartInfo.Arguments = args;
            bool started = processZipalign.Start();
            processZipalign.BeginOutputReadLine();
            processZipalign.BeginErrorReadLine();
            return started;
        }
    }

    public class ZipalignOptions
    {
        public ZipalignOptions(string inputFile, int alignmentInBytes)
        {
            this.InputFile = inputFile;
            this.AlignmentInBytes = alignmentInBytes;
        }

        public string InputFile { get; set; }
        public string OutputFile { get; set; }
        public int AlignmentInBytes { get; set; }
        public bool CheckOnly { get; set; }
        public bool OverwriteOutputFile { get; set; }
        public bool Recompress { get; set; }
        public bool VerboseOut { get; set; }
    }
}
