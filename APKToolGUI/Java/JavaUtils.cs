using APKToolGUI;
using APKToolGUI.Languages;
using APKToolGUI.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace Java
{
    public class JavaUtils
    {
        public static string GetSystemVariable()
        {
            try
            {
                using (Process javaProcess = new Process())
                {
                    javaProcess.StartInfo.FileName = "where";
                    javaProcess.StartInfo.Arguments = "java";
                    javaProcess.StartInfo.CreateNoWindow = true;
                    javaProcess.StartInfo.UseShellExecute = false;
                    javaProcess.StartInfo.RedirectStandardError = true;
                    javaProcess.StartInfo.RedirectStandardOutput = true;
                    javaProcess.Start();
                    string output = javaProcess.StandardOutput.ReadToEnd();
                    javaProcess.WaitForExit();
                    if (!String.IsNullOrEmpty(output))
                    {
                        string[] paths = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string path in paths)
                        {
                            return path;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
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
            if (Settings.Default.UseCustomJavaExe)
            {
                return Settings.Default.JavaExe;
            }
            else
            {
                string javaExec = JavaUtils.GetSystemVariable();
                if (String.IsNullOrEmpty(javaExec))
                {
                    javaExec = JavaUtils.SearchPath();
                    if (File.Exists(javaExec))
                    {
                        return javaExec;
                    }
                }
                return javaExec;
            }
        }
    }
}
