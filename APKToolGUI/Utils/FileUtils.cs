using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    internal class FileUtils
    {
        public static void Move(string sourceFileName, string destFileName, bool overwrite = false)
        {
            if (File.Exists(destFileName) && overwrite)
                File.Delete(destFileName);
            File.Move(sourceFileName, destFileName);
        }

        public static void Copy(string sourceFileName, string destFileName, bool overwrite = false)
        {
            if (File.Exists(sourceFileName))
                File.Copy(sourceFileName, destFileName, overwrite);
        }

        public static void Delete(string sourceFileName)
        {
            if (File.Exists(sourceFileName))
                File.Delete(sourceFileName);
        }
    }
}
