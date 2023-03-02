using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace APKSMerger.Util
{
    /// <summary>
    /// extension methods
    /// </summary>
    public static class ClassExtensions
    {
        /// <summary>
        /// replaces the first occurance of the pattern with the replacement
        /// </summary>
        /// <param name="s">the string to replace in</param>
        /// <param name="pattern">the pattern to replace</param>
        /// <param name="replacement">the replacement for the pattern</param>
        /// <returns>a string in wich the first occurance of the pattern was replaced</returns>
        public static string ReplaceFirst(this string s, string pattern, string replacement)
        {
            int pos = s.IndexOf(pattern);
            if (pos < 0)
            {
                return s;
            }
            return s.Substring(0, pos) + replacement + s.Substring(pos + pattern.Length);
        }

        /// <summary>
        /// does the array contain the string a, ignoring case?
        /// </summary>
        /// <param name="s">the array to check</param>
        /// <param name="a">the string to check for</param>
        /// <returns>contains it?</returns>
        public static bool ContainsIgnoreCase(this string[] s, string a)
        {
            foreach (string sa in s)
            {
                if (sa.Equals(a, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// enumerates all files in the directory (and subdirs if enabled)
        /// </summary>
        /// <param name="dir">the directory to enumerate in</param>
        /// <param name="pattern">the pattern to filter with, eg. *.* or *.txt</param>
        /// <param name="includeSubDirs">should files in subdirs be included?</param>
        /// <param name="action">the action to execute for all files</param>
        public static void EnumerateAllFiles(this DirectoryInfo dir, string pattern, bool includeSubDirs, Action<FileInfo> action)
        {
            foreach (FileInfo file in dir.EnumerateFiles(pattern, includeSubDirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                action.Invoke(file);
            }
        }

        /// <summary>
        /// enumerates all files in the directory (and subdirs if enabled) in parallel
        /// </summary>
        /// <param name="dir">the directory to enumerate in</param>
        /// <param name="pattern">the pattern to filter with, eg. *.* or *.txt</param>
        /// <param name="includeSubDirs">should files in subdirs be included?</param>
        /// <param name="action">the action to execute for all files</param>
        public static void EnumerateAllFilesParallel(this DirectoryInfo dir, string pattern, bool includeSubDirs, Action<FileInfo> action)
        {
            Parallel.ForEach(dir.EnumerateFiles(pattern, includeSubDirs ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly), action);
        }

        /// <summary>
        /// checks if the two files have the same hash (MD5)
        /// </summary>
        /// <param name="a">the first file</param>
        /// <param name="b">the file to compare</param>
        /// <returns>do they have the same hash?</returns>
        public static bool HasSameHash(this FileInfo a, FileInfo b)
        {
            return a.GetMD5().Equals(b.GetMD5());
        }

        /// <summary>
        /// Get the md5 of the file
        /// </summary>
        /// <param name="f">the file to get md5 of</param>
        /// <returns>md5 string of the file</returns>
        public static string GetMD5(this FileInfo f)
        {
            using (MD5 md5 = MD5.Create())
            using (FileStream stream = f.OpenRead())
            {
                return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// repeat the char n times
        /// </summary>
        /// <param name="c">char to repeat</param>
        /// <param name="n">how often to repeat</param>
        /// <returns>string with n time c</returns>
        public static string Repeat(this char c, int n)
        {
            string s = "";
            for (int i = 0; i < n; i++)
                s += c;

            return s;
        }
    }
}
