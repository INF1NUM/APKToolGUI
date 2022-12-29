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

        public static void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            if (Directory.Exists(sourceDirName))
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and copy them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    //Debug.WriteLine(file);
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, true);
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        Copy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
        }

        public static void Move(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                // Get the subdirectories for the specified directory.
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);

                if (!dir.Exists)
                {
                    return;
                    //throw new DirectoryNotFoundException(
                    //    "Source directory does not exist or could not be found: "
                    //    + sourceDirName);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();
                // If the destination directory doesn't exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                // Get the files in the directory and move them to the new location.
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    // File.AppendAllText(s, Path.Combine(destDirName, file.Name) + "\n");
                    //HaveError(Environment.NewLine + ex, MainResources.Some_Error_Found);
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.MoveTo(temppath, true);
                }

                // If copying subdirectories, copy them and their contents to new location.
                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        Move(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }
            catch (PathTooLongException)
            {
                throw new PathTooLongException("Path too long. Skipped");
            }
        }

        public static void Move(string source, string target)
        {
            Delete(target);
            var sourcePath = source.TrimEnd('\\', ' ');
            var targetPath = target.TrimEnd('\\', ' ');
            var files = Directory.EnumerateFiles(sourcePath, "*", SearchOption.AllDirectories)
                                 .GroupBy(s => Path.GetDirectoryName(s));
            foreach (var folder in files)
            {
                var targetFolder = folder.Key.Replace(sourcePath, targetPath);
                Directory.CreateDirectory(targetFolder);
                foreach (var file in folder)
                {
                    var targetFile = Path.Combine(targetFolder, Path.GetFileName(file));
                    if (File.Exists(targetFile)) File.Delete(targetFile);
                    File.Move(file, targetFile);
                }
            }
            Directory.Delete(source, true);
        }

        public static void ReplaceinFiles(string folderPath, string old, string replace, string extenstion = "*")
        {
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, extenstion, SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                {
                    if (File.Exists(filePath))
                    {
                        string file = File.ReadAllText(filePath);
                        if (file.Contains(old))
                        {
                            file = file.Replace(old, replace);
                            File.WriteAllText(filePath, file);
                        }
                    }
                }
            }
        }

        public static void ReplaceinFilesRegex(string folderPath,string pattern, string replace, string extenstion = "*"
        )
        {
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, extenstion, SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                {
                    if (File.Exists(filePath))
                    {
                        string file = File.ReadAllText(filePath);
                        if (Regex.IsMatch(file, pattern))
                        {
                            file = Regex.Replace(file, pattern, replace);
                            File.WriteAllText(filePath, file);
                        }
                    }
                }
            }
        }

        public static void ReplaceinFilesRegex( string folderPath,string[] pattern,string replace,
            string extenstion = "*"
        )
        {
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, extenstion, SearchOption.AllDirectories);
                foreach (string filePath in filePaths)
                {
                    if (File.Exists(filePath))
                    {
                        string file = File.ReadAllText(filePath);
                        foreach (string pat in pattern)
                        {
                            if (Regex.IsMatch(file, pat))
                            {
                                file = Regex.Replace(file, pat, replace);
                                File.WriteAllText(filePath, file);
                            }
                        }
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
