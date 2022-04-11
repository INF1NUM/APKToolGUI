
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    public class CMD
    {
        public static string output;
        static public Process p = new Process();

        public static string ProcessStartWithOutput(string FileName, string Arguments)
        {
            // Debug.WriteLine("CMD: " + FileName + " " + Arguments);
            string result = string.Empty;
            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = FileName;
                    process.StartInfo.Arguments = Arguments;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.StandardOutputEncoding = Encoding.GetEncoding("utf-8");
                    process.Start();
                    result = process.StandardOutput.ReadToEnd().Trim();
                    process.WaitForExit(4000);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Start", e);
            }
            return result;
        }
    }
}
