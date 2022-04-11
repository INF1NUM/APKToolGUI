using APKToolGUI;
using APKToolGUI.Languages;
using APKToolGUI.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Java
{
    public class JavaUtils
    {
        public static bool TryGetSystemVariable(out string javaExeLocation)
        {
            try
            {
                ProcessStartInfo procStartInfo = new ProcessStartInfo("java", "-version ");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.RedirectStandardError = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                if (!String.IsNullOrEmpty(proc.StandardError.ReadToEnd()))
                {
                    javaExeLocation = "java";
                    return true;
                }
                else
                {
                    javaExeLocation = null;
                    return false;
                }
            }
            catch
            {
                javaExeLocation = null;
                return false;
            }
        }
        private static string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            string javaKey = @"SOFTWARE\JavaSoft\Java Runtime Environment\";
            if (Environment.Is64BitOperatingSystem)
                javaKey = @"SOFTWARE\Wow6432Node\JavaSoft\Java Runtime Environment\";

            using (Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(javaKey))
            {
                if (rk != null)
                {
                    string currentVersion = rk.GetValue("CurrentVersion").ToString();
                    using (Microsoft.Win32.RegistryKey key = rk.OpenSubKey(currentVersion))
                        return key.GetValue("JavaHome").ToString();
                }
                else
                    return null;
            }

        }

        public static string SearchPath()
        {
            string installPath = GetJavaInstallationPath();
            if (!String.IsNullOrWhiteSpace(installPath))
            {
                string filePath = System.IO.Path.Combine(installPath, @"bin\Java.exe");
                if (System.IO.File.Exists(filePath))
                    return filePath;
                else
                    return null;
            }
            else
                return null;
        }

        public static string GetJavaPath()
        {
            string javaExec;
            if (!JavaUtils.TryGetSystemVariable(out javaExec))
            {
                javaExec = JavaUtils.SearchPath();
                if (!File.Exists(javaExec))
                {
                    if (MessageBox.Show(Language.DoYouWantToSelectJavaLocation, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (OpenFileDialog openJavaExe = new OpenFileDialog())
                        {
                            openJavaExe.Filter = "java.exe|java.exe";
                            if (openJavaExe.ShowDialog() == DialogResult.OK)
                            {
                                javaExec = Program.GetPortablePath(openJavaExe.FileName);
                            }
                            else
                                Environment.Exit(0);
                        }
                    }
                    else
                        Environment.Exit(0);
                }
                else
                {
                    return javaExec;
                }
            }
            return javaExec;
        }
    }
}
