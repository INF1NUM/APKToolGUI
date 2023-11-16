using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    internal class ProcessUtils
    {
        public static void KillAllProcessesSpawnedBy(UInt32 parentProcessId)
        {
            // NOTE: Process Ids are reused!
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "SELECT * " +
                "FROM Win32_Process " +
                "WHERE ParentProcessId=" + parentProcessId);
            ManagementObjectCollection collection = searcher.Get();
            if (collection.Count > 0)
            {
                foreach (var item in collection)
                {
                    UInt32 childProcessId = (UInt32)item["ProcessId"];
                    if ((int)childProcessId != Process.GetCurrentProcess().Id)
                    {
                        Debug.WriteLine($"Kill child process {childProcessId}");
                        KillAllProcessesSpawnedBy(childProcessId);

                        Process childProcess = Process.GetProcessById((int)childProcessId);
                        childProcess.Kill();
                    }
                }
            }
        }
    }
}
