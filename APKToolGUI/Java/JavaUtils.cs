using System;
using System.Diagnostics;

namespace Java
{
    public class JavaUtils
    {
        private static string GetJavaInstallationPath()
        {
            string environmentPath = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (!string.IsNullOrEmpty(environmentPath))
            {
                return environmentPath;
            }

            string javaKey = "SOFTWARE\\JavaSoft\\Java Runtime Environment\\";
            if (Environment.Is64BitOperatingSystem)
                javaKey = "SOFTWARE\\Wow6432Node\\JavaSoft\\Java Runtime Environment\\";

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
                string filePath = System.IO.Path.Combine(installPath, "bin\\Java.exe");
                if (System.IO.File.Exists(filePath))
                    return filePath;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
