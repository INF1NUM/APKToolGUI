using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Java
{
    public class JarProcess : Process
    {
        public JarProcess(string javaPath, string jarPath)
        {
            this.JavaPath = javaPath;
            this.JarPath = jarPath;
            Initialize();
        }

        private void Initialize()
        {
            this.EnableRaisingEvents = true;
            this.StartInfo.FileName = JavaPath; //задаем имя запускного файла
            this.StartInfo.UseShellExecute = false; //отключаем использование оболочки, чтобы можно было читать данные вывода
            this.StartInfo.RedirectStandardOutput = true; // разрешаем перенаправление данных вывода
            this.StartInfo.RedirectStandardError = true; // разрешаем перенаправление данных вывода
            this.StartInfo.CreateNoWindow = true; //запрещаем создавать окно для запускаемой программы
        }

        public string JavaPath { get; set; }
        public string JarPath { get; set; }

        public new bool Start(string args)
        {
            this.EnableRaisingEvents = true;
            this.StartInfo.Arguments = String.Format("-jar \"{0}\" {1}", JarPath, args);
            return base.Start();
        }
                
        public Version GetJavaVersion()
        {
            using (Process javaProcess = new Process())
            {
                javaProcess.StartInfo.FileName = this.JavaPath;
                javaProcess.StartInfo.Arguments = "-version";
                javaProcess.StartInfo.CreateNoWindow = true;
                javaProcess.StartInfo.UseShellExecute = false;
                javaProcess.StartInfo.RedirectStandardError = true;
                bool started = javaProcess.Start();
                string output = javaProcess.StandardError.ReadToEnd();
                javaProcess.WaitForExit(3000);
                System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(output, @"^java version ""(\d+)\.(\d+)\.(\d+)_(\d+)"".$", System.Text.RegularExpressions.RegexOptions.Multiline);
                if (match.Groups.Count == 5)
                    return new Version(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value), Convert.ToInt32(match.Groups[3].Value), Convert.ToInt32(match.Groups[4].Value));
                else
                    return null;
            }
        }
    }
}
