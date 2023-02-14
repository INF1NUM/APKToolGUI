using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    public static class DirectoryUtils
    {
        public static void Delete(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        public static void Copy(string source, string target)
        {
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);

                //Debug.WriteLine("Create directory: " + folder);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    File.Copy(file, targetFile, true);
                }
            }
        }

        public static void Move(string source, string target)
        {
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);

                //Debug.WriteLine("Create directory: " + folder);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    //try
                    //{
                    //Debug.WriteLine("Move file: " + file);
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    File.Copy(file, targetFile, true);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Debug.WriteLine("Error moving file: " + file + " (" + ex.Message + ")");
                    //}
                }
            }
            Directory.Delete(source, true);
        }

        public static void ReplaceinFiles(
             string folderPath,
             string old,
             string replace,
            string extenstion = "*"
        )
        {
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo DR = new DirectoryInfo(folderPath);
                var filePaths = DR.EnumerateFiles(extenstion, SearchOption.AllDirectories).AsParallel();
                foreach (FileInfo filePath in filePaths)
                {
                    if (File.Exists(filePath.FullName))
                    {
                        string file = File.ReadAllText(filePath.FullName);
                        if (file.Contains(old))
                        {
                            file = file.Replace(old, replace);
                            File.WriteAllText(filePath.FullName, file);
                        }
                    }
                }
            }
        }

        public static void ReplaceinFilesRegex(
            string folderPath,
            string pattern,
            string replace,
            string extenstion = "*"
        )
        {
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo DR = new DirectoryInfo(folderPath);
                var filePaths = DR.EnumerateFiles(extenstion, SearchOption.AllDirectories).AsParallel();
                foreach (FileInfo filePath in filePaths)
                {
                    if (File.Exists(filePath.FullName))
                    {
                        string file = File.ReadAllText(filePath.FullName);
                        if (Regex.IsMatch(file, pattern))
                        {
                            file = Regex.Replace(file, pattern, replace);
                            File.WriteAllText(filePath.FullName, file);
                        }
                    }
                }
            }
        }


        public static void ReplaceinFilesRegex(
            string folderPath,
            string[] pattern,
            string replace,
            string extenstion = "*.*"
        )
        {
            if (Directory.Exists(folderPath))
            {
                DirectoryInfo DR = new DirectoryInfo(folderPath);
                var filePaths = DR.EnumerateFiles(extenstion, SearchOption.AllDirectories).AsParallel();
                foreach (FileInfo filePath in filePaths)
                {
                    if (File.Exists(filePath.FullName))
                    {
                        bool match = false;
                        string file = File.ReadAllText(filePath.FullName);
                        foreach (string pat in pattern)
                        {
                            if (Regex.IsMatch(file, pat))
                            {
                                file = Regex.Replace(file, pat, replace);
                                match = true;
                            }
                        }
                        if (match)
                            File.WriteAllText(filePath.FullName, file);
                    }
                }
            }
        }

        public static void MoveTo(this FileInfo file, string destination, bool autoCreateDirectory)
        {
            if (autoCreateDirectory)
            {
                var destinationDirectory = new DirectoryInfo(Path.GetDirectoryName(destination));

                if (!destinationDirectory.Exists)
                    destinationDirectory.Create();
            }

            file.MoveTo(destination);
        }
    }
}
