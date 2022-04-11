using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    public class PathUtils
    {
        public static bool IsValidPath(string path)
        {
            try
            {
                Path.GetFileName(path);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;

            //if (path.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1)
            //    return false;
            //else
            //    return true;

        }

        public static string GetDirectoryNameWithoutExtension(string path)
        {
            return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path));
        }
    }
}
