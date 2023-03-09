using APKToolGUI.Properties;
using APKToolGUI.Utils;
using Java;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Shapes;

namespace APKToolGUI
{
    public class Adb
    {
        Process processAdb;
        static class Keys
        {
            public const string Devices = " devices -l"; //list connected devices (-l for long output)
            public const string Serial = " -s"; // use device with given serial (overrides $ANDROID_SERIAL)
            public const string Vendor = " -i"; //Vendor
            public const string ApkPath = " -r";
            public const string Abi = " --abi armeabi-v7a";
        }

        public event DataReceivedEventHandler OutputDataReceived
        {
            add { processAdb.OutputDataReceived += value; }
            remove { processAdb.OutputDataReceived -= value; }
        }

        public event DataReceivedEventHandler ErrorDataReceived
        {
            add { processAdb.ErrorDataReceived += value; }
            remove { processAdb.ErrorDataReceived -= value; }
        }

        public event EventHandler Exited;
        public int ExitCode { get { return processAdb.ExitCode; } }
        string adbFileName = null;
        public Adb(string AdbFileName)
        {
            adbFileName = AdbFileName;
            processAdb = new Process();
            processAdb.EnableRaisingEvents = true;
            processAdb.StartInfo.FileName = AdbFileName;
            processAdb.StartInfo.UseShellExecute = false; //отключаем использование оболочки, чтобы можно было читать данные вывода
            processAdb.StartInfo.RedirectStandardOutput = true; // разрешаем перенаправление данных вывода
            processAdb.StartInfo.RedirectStandardError = true; // разрешаем перенаправление данных вывода
            processAdb.StartInfo.CreateNoWindow = true; //запрещаем создавать окно для запускаемой программы
            processAdb.Exited += processAdb_Exited;
        }

        void processAdb_Exited(object sender, EventArgs e)
        {
            processAdb.CancelOutputRead();
            processAdb.CancelErrorRead();
            if (this.Exited != null)
                Exited(this, new EventArgs());
        }

        public void Cancel()
        {
            try
            {
                if (processAdb.HasExited == false)
                {
                    processAdb.Kill();
                }
            }
            catch { }
        }

        public int Install(string device, string inputApk)
        {
            Regex regex = new Regex(@"^(\S+)\s+.*model:(\w+).*");
            Match mdevice = regex.Match(device);

            string setVendor = null;
            if (Settings.Default.Adb_SetVendor)
                setVendor = $"{Keys.Vendor} com.android.vending {Keys.ApkPath}";

            string args = String.Format($"{Keys.Serial} {mdevice.Groups[1].Value} install {setVendor} \"{inputApk}\"");

            Debug.WriteLine("Adb: " + args);

            processAdb.EnableRaisingEvents = false;
            processAdb.StartInfo.Arguments = args;
            processAdb.Start();
            processAdb.BeginOutputReadLine();
            processAdb.BeginErrorReadLine();
            processAdb.WaitForExit();

            return ExitCode;
        }

        public string GetDevices()
        {
            Process process = new Process();
            process.EnableRaisingEvents = true;
            process.StartInfo.FileName = adbFileName;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.EnableRaisingEvents = false;
            process.StartInfo.Arguments = Keys.Devices;
            process.Start();
            string devices = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return devices;
        }

        public void KillProcess()
        {
            foreach (var process in Process.GetProcessesByName("adb"))
            {
                process.Kill();
            }
        }
    }
}
