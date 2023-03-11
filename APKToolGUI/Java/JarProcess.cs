using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Java
{
    public class JarProcess : Process
    {
        public string JavaPath { get; set; }
        public string JarPath { get; set; }

        public JarProcess(string javaPath, string jarPath)
        {
            JavaPath = javaPath.Equals("java") ? "" : javaPath;
            JarPath = jarPath;
            Initialize();
        }

        private void Initialize()
        {
            EnableRaisingEvents = true;
            StartInfo.FileName = JavaPath;
            StartInfo.StandardOutputEncoding = Encoding.GetEncoding("UTF-8");
            StartInfo.UseShellExecute = false;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.CreateNoWindow = true;
        }

        public new bool Start(string args)
        {
            EnableRaisingEvents = true;
            StartInfo.Arguments = String.Format("-jar \"{0}\" {1}", JarPath, args);
            Debug.WriteLine(String.Format("-jar \"{0}\" {1}", JarPath, args));
            return base.Start();
        }

        public string GetString(string args)
        {
            try
            {
                using (Process javaProcess = new Process())
                {
                    javaProcess.StartInfo.FileName = JavaPath;
                    javaProcess.StartInfo.Arguments = String.Format("-jar \"{0}\" {1}", JarPath, args);
                    javaProcess.StartInfo.CreateNoWindow = true;
                    javaProcess.StartInfo.UseShellExecute = false;
                    javaProcess.StartInfo.RedirectStandardError = true;
                    javaProcess.StartInfo.RedirectStandardOutput = true;
                    javaProcess.Start();
                    string output = javaProcess.StandardOutput.ReadToEnd();
                    javaProcess.WaitForExit(3000);
                    if (!String.IsNullOrEmpty(output))
                        return output;
                    else
                        return null;
                }
            }
            catch
            {
                throw;
            }
        }

        public string GetJavaVersion()
        {
            try
            {
                using (Process javaProcess = new Process())
                {
                    javaProcess.StartInfo.FileName = JavaPath;
                    javaProcess.StartInfo.Arguments = "-version";
                    javaProcess.StartInfo.CreateNoWindow = true;
                    javaProcess.StartInfo.UseShellExecute = false;
                    javaProcess.StartInfo.RedirectStandardError = true;
                    javaProcess.Start();
                    string output = javaProcess.StandardError.ReadToEnd();
                    javaProcess.WaitForExit(3000);
                    if (!String.IsNullOrEmpty(output))
                        return output = output.Remove(output.LastIndexOf(Environment.NewLine));
                    else
                        return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
