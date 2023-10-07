using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace APKToolGUI.Utils
{
    public class ZipUtils
    {
        public static void ExtractAllStream(string path, string embeddedZip)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _zipFileStream = _assembly.GetManifestResourceStream(embeddedZip);
            using (ZipFile zipFile = ZipFile.Read(_zipFileStream))
            {
                zipFile.ExtractAll(path);
            }
        }

        public static string GetFileName(string path, string fileNameContains, string folderContains = "")
        {
            using (ZipFile zipDest = ZipFile.Read(path))
            {
                foreach (ZipEntry entry in zipDest.Entries)
                {
                    if (entry.FileName.Contains(fileNameContains) && entry.FileName.Contains(folderContains))
                        return Path.GetFileName(entry.FileName);
                }
            }
            return "";
        }

        public static string GetFileNameWithoutExtension(string path, string fileNameContains, string folderContains = "")
        {
            using (ZipFile zipDest = ZipFile.Read(path))
            {
                foreach (ZipEntry entry in zipDest.Entries)
                {
                    if (entry.FileName.Contains(fileNameContains) && entry.FileName.Contains(folderContains))
                        return Path.GetFileNameWithoutExtension(entry.FileName);
                }
            }
            return "";
        }
        public static bool Exists(string path, string fileNameContains, string folderContains = "")
        {
            using (ZipFile zipDest = ZipFile.Read(path))
            {
                foreach (ZipEntry entry in zipDest.Entries)
                {
                    if (entry.FileName.Contains(fileNameContains) && String.IsNullOrEmpty(folderContains))
                        return true;
                    else if (entry.FileName.Contains(fileNameContains) && entry.FileName.Contains(folderContains))
                        return true;
                }
            }
            return false;
        }

        public static void AddFile(string zipFile, string fileName, string directoryPathInArchive = "")
        {
            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                if (!String.IsNullOrEmpty(directoryPathInArchive))
                    zip.AddFile(fileName, directoryPathInArchive);
                else
                    zip.AddFile(fileName);
                zip.Save();
            }
        }

        public static void UpdateFile(string zipFile, string fileName, string directoryPathInArchive = "")
        {
            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                if (!String.IsNullOrEmpty(directoryPathInArchive))
                    zip.UpdateFile(fileName, directoryPathInArchive);
                else
                    zip.UpdateFile(fileName);
                zip.Save();
            }
        }

        public static void RemoveFile(string zipFile, string fileName)
        {
            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                bool chkresult2 = zip.Any(entry => entry.FileName.Contains(fileName));
                if (chkresult2)
                {
                    zip.RemoveEntry(fileName);
                    zip.Save();
                }
            }
        }

        public static void ExtractFile(string path, string fileName, string destination)
        {
            using (ZipFile zip = ZipFile.Read(path))
            {
                bool chkresult2 = zip.Any(entry => entry.FileName.Contains(fileName));
                if (chkresult2)
                {
                    zip.FlattenFoldersOnExtract = true;
                    ZipEntry e = zip[fileName];
                    e.Extract(destination, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        public static void ExtractAll(string path, string destination, bool flattenFoldersOnExtract = false)
        {
            using (ZipFile zip = ZipFile.Read(path))
            {
                zip.FlattenFoldersOnExtract = flattenFoldersOnExtract;
                zip.ExtractAll(destination, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        public static void AddDirectory(string path, string fileName, string directoryPathInArchive = "")
        {
            ZipFile zip = new ZipFile();
            if (!String.IsNullOrEmpty(directoryPathInArchive))
                zip.AddDirectory(fileName, directoryPathInArchive);
            else
                zip.AddDirectory(fileName);
            zip.Save(path);
        }

        public static void UpdateDirectory(string path, string dirName, string directoryPathInArchive = "")
        {
            using (ZipFile zip = ZipFile.Read(path))
            {
                if (!String.IsNullOrEmpty(directoryPathInArchive))
                    zip.UpdateDirectory(dirName, directoryPathInArchive);
                else
                    zip.UpdateDirectory(dirName);
                zip.Save();
            }
        }

        public static void ExtractDirectory(string path, string folderName, string destination, bool flattenFoldersOnExtract = false)
        {
            //using (ZipFile zip = ZipFile.Read(path))
            //{
            //    bool chkresult2 = zip.Any(entry => entry.FileName.Contains(folderName));
            //    if (chkresult2)
            //    {
            //        zip.FlattenFoldersOnExtract = flattenFoldersOnExtract;
            //        zip.ExtractSelectedEntries("name = *", folderName, destination, ExtractExistingFileAction.OverwriteSilently);
            //    }
            //}
            using (ZipFile zip = ZipFile.Read(path))
            {
                zip.FlattenFoldersOnExtract = flattenFoldersOnExtract;
                foreach (ZipEntry e in zip.Where(x => x.FileName.Contains(folderName)))
                {
                    e.Extract(destination, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

    }
}
