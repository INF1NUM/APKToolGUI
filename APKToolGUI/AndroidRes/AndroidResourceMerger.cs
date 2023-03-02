//https://github.com/shadow578/ApksMerger

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using APKSMerger.AndroidRes.Model;
using APKSMerger.AndroidRes.Model.Generic;
using APKSMerger.Util;
using APKToolGUI.Utils;

namespace APKSMerger.AndroidRes
{
    /// <summary>
    /// merges android resource files
    /// </summary>
    public sealed class AndroidMerger
    {
        /// <summary>
        /// check capabilities of the base and splits, warn if (common) libs are missing
        /// </summary>
        /// <param name="locales">list of supported locales; key is locale, value is name of dir that first included it</param>
        /// <param name="abis">list of supported abis; key is abi, value is name of dir that first included it</param>
        /// <param name="baseDir">base project dir</param>
        /// <param name="splits">split dirs</param>
        public void CollectCapabilities(out Dictionary<string, string> locales, out Dictionary<string, string> abis,
        DirectoryInfo baseDir, params DirectoryInfo[] splits)
        {
            //init dicts
            Log.i("collecting info about splits...");
            locales = new Dictionary<string, string>();
            abis = new Dictionary<string, string>();

            //combine base and splits into one list
            List<DirectoryInfo> allDir = new List<DirectoryInfo>();
            allDir.Add(baseDir);
            allDir.AddRange(splits);

            //check all dirs, collect infos about them
            foreach (DirectoryInfo d in allDir)
            {
                //check exists
                if (!d.Exists)
                {
                    Directory.CreateDirectory(baseDir.FullName);
                    Log.w($"Create baseDir {baseDir.FullName}");
                    continue;
                }

                //get all library archs included in this dir
                //a decompiled apk dir may have a lib directory that contains native libraries for all archs supported by that apk (or split)
                //the archs are splitted into their own directories, depending on the arch they're for
                string libsDir = Path.Combine(d.FullName, "lib");
                if (Directory.Exists(libsDir))
                {
                    foreach (string arch in Directory.EnumerateDirectories(libsDir))
                    {
                        //get name of arch
                        string archName = Path.GetFileName(arch);

                        //add arch to lists of abis
                        if (!abis.ContainsKey(archName))
                        {
                            Log.v($"{d.Name} includes abi {archName}");
                            abis.Add(archName, d.Name);
                        }
                        else
                        {
                            //double arch?
                            Log.w($"arch {archName} already included by {abis[archName]} - in {d.Name}");
                        }
                    }
                }
                else
                {
                    Log.v($"{d.Name} does not include abis");
                }

                //get all locales included in this dir
                //extra locales are defined in strings.xml files in directories named values-<LOCALE_NAME>
                //locale name seems to be formatted as ISO 639, but with an extra r (so en-GB == en-rGB)
                string resDir = Path.Combine(d.FullName, "res");
                if (Directory.Exists(resDir))
                {
                    //add all dirs matching pattern (like values-en-rGB)
                    foreach (string lang in Directory.EnumerateDirectories(resDir, @"values-*"))
                    {
                        //check directory contains a strings.xml
                        if (!File.Exists(Path.Combine(lang, "strings.xml")))
                            continue;

                        //get name of lang
                        string langName = Path.GetFileName(lang).ReplaceFirst("values-", "");

                        //add lang to list of locales
                        if (!locales.ContainsKey(langName))
                        {
                            Log.v($"{d.Name} included locale {langName}");
                            locales.Add(langName, d.Name);
                        }
                        else
                        {
                            //double lang?
                            Log.w($"locale {langName} already included by {locales[langName]} - in {d.Name}");
                        }
                    }
                }
                else
                {
                    Log.v($"{d.Name} does not include locales");
                }
            }
        }

        /// <summary>
        /// merge all splits into the base project dir
        /// </summary>
        /// <param name="baseDir">base project dir</param>
        /// <param name="splits">split dirs to merge</param>
        public void MergeSplits(DirectoryInfo baseDir, params DirectoryInfo[] splits)
        {
            //Log.v($"Base dir: {baseDir.FullName}");
            //check all dirs exists
            if (!baseDir.Exists)
            {
                Directory.CreateDirectory(baseDir.FullName);
                Log.w($"Create baseDir {baseDir.FullName}");
                //return;
            }

            foreach (DirectoryInfo dir in splits)
            {
                //Debug.WriteLine(dir);
                if (!dir.Exists)
                {
                    Log.e($"split dir {dir.FullName} dos not exist!");
                    return;
                }
            }

            List<string> assetPacks = new List<string>();
            //enumarate all splitted files
            Dictionary</*original*/string, /*replacement*/string> globalNameReplacements = new Dictionary<string, string>();
            foreach (DirectoryInfo split in splits)
            {
                //Log.v($"Split dir: {split.FullName}");
                split.EnumerateAllFiles("*.*", true, (FileInfo splittedFile) =>
                {
                    if (splittedFile.FullName.Contains("AndroidManifest.xml"))
                    {
                        string manifest = File.ReadAllText(splittedFile.FullName);
                        string splitModule = StringExt.Regex(@"(?<= split=\"")(.*?)(?=\"")", manifest);

                        if (!String.IsNullOrEmpty(splitModule) && manifest.Contains("dist:type=\"asset-pack\""))
                        {
                            Log.v($"Add module: {splitModule}");
                            assetPacks.Add(splitModule);
                        }
                    }

                    //Debug.WriteLine($"Splited file: {splittedFile.FullName}");
                    //check if should process
                    string splitRel = PathUtils.GetRelativePath(split.FullName, splittedFile.FullName);
                    if (!ShouldProcess(splittedFile, split))
                    {
                        //Log.v($"skip excluded split file {splitRel}");
                        return;
                    }

                    //Debug.WriteLine($"Split rel dir: {splitRel}");
                    //Debug.WriteLine($"base Dir: {baseDir.FullName}");
                    List<string> splitList = splitRel.Split('\\').ToList();
                    splitList.RemoveAt(0);
                    string outputString = string.Join("\\", splitList);

                    //get file path for base dir
                    FileInfo baseFile = new FileInfo(Path.Combine(baseDir.FullName, outputString));
                    //Debug.WriteLine($"Base file: {baseFile}");
                    //Log.v($"Base file: {baseFile}");

                    //create target dir in base if needed
                    string baseFileDir = Path.GetDirectoryName(baseFile.FullName);
                    //Log.v($"Base file´dir: {baseFileDir}");
                    //Debug.WriteLine($"Base file dir: {baseFileDir}");
                    if (!Directory.Exists(baseFileDir))
                    {
                        Directory.CreateDirectory(baseFileDir);
                    }

                    //check file exists in base and is resource xml
                    if (!IsResourceXml(baseFile))
                    {
                        //nothing to merge, just copy
                        Log.v($"Move split file {splitRel} to {baseFile}");
                        if (File.Exists(baseFile.FullName))
                            File.Delete(baseFile.FullName);
                        splittedFile.MoveTo(baseFile.FullName);
                    }
                    else
                    {
                        //already exists, merge
                        //Debug.WriteLine($"Merge split file {splitRel} with {baseFile}");

                        //skip if files are equal
                        if (baseFile.HasSameHash(splittedFile))
                        {
                            Log.vv($"base and split of {splitRel} have same hash, skipping...");
                            return;
                        }

                        //check base and split are both resource xmls, if not skip
                        if (/*!IsResourceXml(baseFile) ||*/ !IsResourceXml(splittedFile))
                        {
                            Log.vv($"split of {splitRel} is not resource xml, skipping...");
                            return;
                        }

                        if (splittedFile.FullName.Contains("styles.xml"))
                        {
                            Debug.WriteLine("Break");
                        }

                        //merge
                        MergeResourceXML(baseFile, splittedFile, globalNameReplacements);
                    }
                });
            }

            //skip replacement if no global name replacements are available
            if (globalNameReplacements.Count <= 0)
            {
                Log.d("skip global name replacements: count is 0");
            }

            //replace names globally (in xml only)
            Log.d($"process {globalNameReplacements.Count} global name replacements...");
            foreach (string org in globalNameReplacements.Keys)
            {
                Log.v($"Replace {org} with {globalNameReplacements[org]}");
                //Debug.Write($"replace {org} with {globalNameReplacements[org]}");
            }

            baseDir.EnumerateAllFiles("*.xml", true, (FileInfo file) =>
            {
                //Debug.WriteLine($"Name replace in {file.FullName}");

                //create temp file
                FileInfo temp = new FileInfo(Path.GetTempFileName());

                //copy from input to temp, replace everything on replace list
                using (StreamReader inp = file.OpenText())
                using (StreamWriter oup = temp.CreateText())
                {

                    string ln;
                    while ((ln = inp.ReadLine()) != null)
                    {
                        //replace all
                        foreach (string org in globalNameReplacements.Keys)
                        {
                            string dummy = StringExt.Regex(@"APKTOOL_DUMMY_([A-Za-z0-9])\w", ln);

                            if (ln.Contains(dummy))
                            {
                                //To avoid replacing wrong dummies. Don't know if there is better way
                                ln = ln.Replace(org + "<", globalNameReplacements[org] + "<");
                                ln = ln.Replace(org + "\"", globalNameReplacements[org] + "\"");
                                //Debug.WriteLine($"Replaced {org} with {globalNameReplacements[org]} in {file.FullName}");
                            }
                            //if (ln.Contains(org))
                            //    ln = Regex.Replace(ln, @"APKTOOL_DUMMY_([A-Za-z0-9])\w", globalNameReplacements[org]);
                        }

                        //write back
                        oup.WriteLine(ln);
                    }
                }

                //move temp to input and delete temp if still exists
                string tempPath = temp.FullName;

                if (File.Exists(file.FullName))
                {
                    File.Delete(file.FullName);
                }

                temp.MoveTo(file.FullName);

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
                }
            });

            //remove splits from android manifest
            FileInfo baseManifest = new FileInfo(Path.Combine(baseDir.FullName, "AndroidManifest.xml"));
            PatchManifest(baseManifest, assetPacks);

            FileInfo baseYml = new FileInfo(Path.Combine(baseDir.FullName, "apktool.yml"));
            PatchYml(baseYml, assetPacks);
        }

        /// <summary>
        /// Patch the AndroidManifest.xml to not use splits
        /// </summary>
        /// <param name="manifest">the manifest xml to patch</param>
        void PatchManifest(FileInfo manifest, List<string> assetPacks)
        {
            Log.d($"patching manifest {manifest.FullName}...");

            //check the file exists
            if (!manifest.Exists)
            {
                Log.e("manifest to patch does not exist!");
                return;
            }

            string modules = null;
            if (assetPacks.Count != 0)
            {
                foreach (string asset in assetPacks)
                {
                    modules += "," + asset;
                }
            }

            //prepare targets to remove
            string[] replaceTargets = { @"android:isSplitRequired=""true""" };

            List<string> removeTargets = new List<string> { @"meta-data android:name=""com.android.stamp.source""",
                @"meta-data android:name=""com.android.vending.derived.apk.id""",
                @"meta-data android:name=""com.android.vending.splits.required""",
                @"meta-data android:name=""com.android.vending.splits"""};

            //create temp file
            FileInfo temp = new FileInfo(Path.GetTempFileName());

            //copy from input to temp, replace everything on replace list
            using (StreamReader inp = manifest.OpenText())
            using (StreamWriter oup = temp.CreateText())
            {
                string ln;
                while ((ln = inp.ReadLine()) != null)
                {
                    //remove all
                    foreach (string target in replaceTargets)
                    {
                        ln = ln.Replace(target, "");
                    }

                    if (removeTargets.Any(w => ln.Contains(w)))
                        continue;

                    if (ln.Contains("STAMP_TYPE_DISTRIBUTION_APK"))
                        ln = ln.Replace("STAMP_TYPE_DISTRIBUTION_APK", "STAMP_TYPE_STANDALONE_APK");

                    if (ln.Contains("</application>") && !String.IsNullOrEmpty(modules))
                    {
                        oup.WriteLine(@"        <meta-data android:name=""com.android.dynamic.apk.fused.modules"" android:value=""base" + modules + @"""/>");
                    }

                    //write back
                    oup.WriteLine(ln);
                }
            }

            //move temp to input and delete temp if still exists
            string tempPath = temp.FullName;

            if (File.Exists(manifest.FullName))
            {
                File.Delete(manifest.FullName);
            }

            temp.MoveTo(manifest.FullName);

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }

        void PatchYml(FileInfo yml, List<string> assetPacks)
        {
            Log.d($"patching apktool.yml {yml.FullName}...");

            //check the file exists
            if (!yml.Exists)
            {
                Log.e("manifest to patch does not exist!");
                return;
            }

            //create temp file
            FileInfo temp = new FileInfo(Path.GetTempFileName());

            //copy from input to temp, replace everything on replace list
            using (StreamReader inp = yml.OpenText())
            using (StreamWriter oup = temp.CreateText())
            {
                string ln;
                while ((ln = inp.ReadLine()) != null)
                {
                    if (ln.Contains("doNotCompress:") && assetPacks.Count != 0)
                    {
                        oup.WriteLine(ln);
                        foreach (string asset in assetPacks)
                        {
                            oup.WriteLine("- assets/assetpack/" + asset);
                        }
                        continue;
                    }

                    //write back
                    oup.WriteLine(ln);
                }
            }

            //move temp to input and delete temp if still exists
            string tempPath = temp.FullName;

            if (File.Exists(yml.FullName))
            {
                File.Delete(yml.FullName);
            }

            temp.MoveTo(yml.FullName);

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }

        /// <summary>
        /// merge two splitted resource xmls, overwrite a with merged
        /// </summary>
        /// <param name="a">file a to merge</param>
        /// <param name="b">file b to merge</param>
        /// <param name="globalNameReplacements">dictionary that can be used to replace names of resources globally</param>
        void MergeResourceXML(FileInfo a, FileInfo b, Dictionary</*original*/string, /*replacement*/string> globalNameReplacements)
        {
            //deserialize both
            AndroidResources resBase = AndroidResources.FromFile(a.FullName);
            AndroidResources resSplit = AndroidResources.FromFile(b.FullName);

            //merge resources to resA
            foreach (AndroidResource res in resSplit.Values)
            {
                if (res is AndroidPublic splitP)
                {
                    //entry of public.xml, special merge (Id has to be unique)
                    //try to find public with same id in base apk
                    AndroidPublic baseP = resBase.FindPublicWithId(splitP.Id);
                    if (baseP == null || !baseP.Type.Equals(splitP.Type))
                    {
                        //id not found or wrong type, add from split
                        resBase.Values.Add(splitP);
                    }
                    else
                    {
                        //id with correct type found in base, 
                        //check if name of base is apktool dummy and name of split is not
                        if (baseP.Name.StartsWith("APKTOOL_DUMMY") && !splitP.Name.StartsWith("APKTOOL_DUMMY"))
                        {
                            try
                            {
                                Log.v($"Replace {baseP.Name} with {splitP.Name}...");
                                globalNameReplacements.Add(baseP.Name, splitP.Name);
                                baseP.Name = splitP.Name;
                            }
                            catch (Exception ex)
                            {
                                Log.v($"Error replacing {baseP.Name} with {splitP.Name}...");
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    //normal resource entry (string / color / ...)
                    if (!resBase.Values.Contains(res))
                    {

                        resBase.Values.Add(res);
                    }
                }
            }

            //serialize back to a
            resBase.ToFile(a.FullName);
        }

        /// <summary>
        /// check if the xml file contains the resources xml tag
        /// </summary>
        /// <param name="xml">the xml to check</param>
        /// <returns>does the xml contain the tag?</returns>
        bool IsResourceXml(FileInfo f)
        {
            //check file exists
            if (!f.Exists) return false;

            try
            {
                //Net reactor cause error
                //check xml root
                XmlDocument xml = new XmlDocument();

                xml.Load(f.FullName);
                //Log.v($"IsResourceXml 5");
                return xml.DocumentElement.Name.Equals("resources", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                //probably bad xml
                return false;
            }
        }

        /// <summary>
        /// should the file be processed?
        /// Example for files to exclude from processing are AndroidManifest.xml, apktool.yml, and META-INF/*
        /// </summary>
        /// <param name="file">the file to check</param>
        /// <param name="projDir">the project dir the file is in</param>
        /// <returns>process the file?</returns>
        bool ShouldProcess(FileInfo file, DirectoryInfo projDir)
        {
            //get relative path
            string filePathRel = PathUtils.GetRelativePath(projDir.FullName, file.FullName).TrimStart('/').TrimStart('\\');

            //check if in META-INF (exclude all)
            //if (filePathRel.StartsWith("META-INF", StringComparison.OrdinalIgnoreCase))
            //    return false;

            //check if in original (exlude all)
            if (filePathRel.StartsWith("original", StringComparison.OrdinalIgnoreCase))
                return false;

            //check if AndroidManifest.xml OR apktool.yml
            if (file.Name.Equals("androidmanifest.xml", StringComparison.OrdinalIgnoreCase)
                || file.Name.Equals("apktool.yml", StringComparison.OrdinalIgnoreCase))
                return false;

            //check if AndroidManifest.xml OR apktool.yml
            if (file.Name.Equals("resources.arsc", StringComparison.OrdinalIgnoreCase))
                return false;

            //check if drawables.yml
            //if (file.Name.Equals("drawables.xml", StringComparison.OrdinalIgnoreCase))
            //    return false;

            //all ok, include
            return true;
        }
    }
}
