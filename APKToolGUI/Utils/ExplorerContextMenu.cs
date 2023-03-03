using System;
using Microsoft.Win32;
using APKToolGUI.Languages;
using APKToolGUI.Utils;
using Microsoft.Build.Framework.XamlTypes;

namespace APKToolGUI
{
    public class ExplorerContextMenu
    {
        public static Status Create()
        {
            string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (AdminUtils.IsAdministrator())
            {
                return CreateContextMenu(executablePath);
            }
            else
                return new Status(false, "Administrator rights are required");
        }

        private static Status CreateContextMenu(string executablePath)
        {
            try
            {
                #region Add context menu to registry
                RegistryKey apkToolGUIFolderShell = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey(Program.APP_NAME, RegistryKeyPermissionCheck.ReadWriteSubTree);
                apkToolGUIFolderShell.SetValue("Icon", executablePath);
                apkToolGUIFolderShell.SetValue("MUIVerb", Program.APP_NAME);
                apkToolGUIFolderShell.SetValue("SubCommands", "APKToolGUI.Build;APKToolGUI.Smali");
                apkToolGUIFolderShell.Close();

                CreateFileAssociationsSubKey(executablePath, ".apk", "APKToolGUI.Decompile;APKToolGUI.Sign;APKToolGUI.Zipalign");
                CreateFileAssociationsSubKey(executablePath, ".xapk", "APKToolGUI.Decompile");
                CreateFileAssociationsSubKey(executablePath, ".apks", "APKToolGUI.Decompile");
                CreateFileAssociationsSubKey(executablePath, ".zip", "APKToolGUI.Decompile");
                CreateFileAssociationsSubKey(executablePath, ".apkm", "APKToolGUI.Decompile");

                CreateFileAssociationsSubKey(executablePath, ".dex", "APKToolGUI.Baksmali");
                #endregion

                #region Add command to registry
                RegistryKey shell;
                if (Environment.Is64BitOperatingSystem)
                    shell = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                else
                    shell = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                RegistryKey decompile = shell.CreateSubKey("APKToolGUI.Decompile", RegistryKeyPermissionCheck.ReadWriteSubTree);
                decompile.SetValue("", Language.DecompileApk, RegistryValueKind.String);
                decompile.SetValue("Icon", executablePath, RegistryValueKind.String);
                decompile.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"decapk\" \"%1\"");
                decompile.Close();

                RegistryKey build = shell.CreateSubKey("APKToolGUI.Build", RegistryKeyPermissionCheck.ReadWriteSubTree);
                build.SetValue("", Language.CompileApk, RegistryValueKind.String);
                build.SetValue("Icon", executablePath, RegistryValueKind.String);
                build.CreateSubKey("command").SetValue("", "\"" + executablePath + "\" \"comapk\" \"%1\"", RegistryValueKind.String);
                build.Close();

                RegistryKey sign = shell.CreateSubKey("APKToolGUI.Sign", RegistryKeyPermissionCheck.ReadWriteSubTree);
                sign.SetValue("", Language.SignApk, RegistryValueKind.String);
                sign.SetValue("Icon", executablePath, RegistryValueKind.String);
                sign.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"sign\" \"%1\"");
                sign.Close();

                RegistryKey zipalign = shell.CreateSubKey("APKToolGUI.Zipalign", RegistryKeyPermissionCheck.ReadWriteSubTree);
                zipalign.SetValue("", Language.ZipalignApk, RegistryValueKind.String);
                zipalign.SetValue("Icon", executablePath, RegistryValueKind.String);
                zipalign.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"zipalign\" \"%1\"");
                zipalign.Close();

                RegistryKey baksmali = shell.CreateSubKey("APKToolGUI.Baksmali", RegistryKeyPermissionCheck.ReadWriteSubTree);
                baksmali.SetValue("", Language.DecompileDex, RegistryValueKind.String);
                baksmali.SetValue("Icon", executablePath, RegistryValueKind.String);
                baksmali.CreateSubKey("command").SetValue("", "\"" + executablePath + "\" \"baksmali\" \"%1\"", RegistryValueKind.String);
                baksmali.Close();

                RegistryKey smali = shell.CreateSubKey("APKToolGUI.Smali", RegistryKeyPermissionCheck.ReadWriteSubTree);
                smali.SetValue("", Language.CompileDex, RegistryValueKind.String);
                smali.SetValue("Icon", executablePath, RegistryValueKind.String);
                smali.CreateSubKey("command").SetValue("", "\"" + executablePath + "\" \"smali\" \"%1\"", RegistryValueKind.String);
                smali.Close();

                RegistryKey apkinfo = shell.CreateSubKey("APKToolGUI.Apkinfo", RegistryKeyPermissionCheck.ReadWriteSubTree);
                apkinfo.SetValue("", Language.GetApkInfo, RegistryValueKind.String);
                apkinfo.SetValue("Icon", executablePath, RegistryValueKind.String);
                apkinfo.CreateSubKey("command").SetValue("", "\"" + executablePath + "\" \"apkinfo\" \"%1\"", RegistryValueKind.String);
                apkinfo.Close();

                shell.Close();
                #endregion
            }
            catch (Exception exc)
            {
                return new Status(false, exc.Message);
            }

            return new Status(true, "Done!");
        }

        public static void CreateFileAssociationsSubKey(string executablePath, string fileExtension, string subCommands)
        {
            Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey(fileExtension, RegistryKeyPermissionCheck.ReadWriteSubTree).CreateSubKey("DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", executablePath, RegistryValueKind.ExpandString);

            RegistryKey shell = Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\" + fileExtension, RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.CreateSubKey).CreateSubKey("shell", RegistryKeyPermissionCheck.ReadWriteSubTree).CreateSubKey(Program.APP_NAME, RegistryKeyPermissionCheck.ReadWriteSubTree);

            shell.SetValue("Icon", "\"" + executablePath + "\"");
            shell.SetValue("MUIVerb", Program.APP_NAME);
            shell.SetValue("SubCommands", subCommands);
            shell.Close();
        }

        public static Status Remove()
        {
            try
            {
                Registry.ClassesRoot.OpenSubKey(@"Directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("APKToolGUI", false);

                Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("DefaultIcon", false);

                Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKey("APKToolGUI", false);

                RegistryKey shell;
                if (Environment.Is64BitOperatingSystem)
                    shell = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                else
                    shell = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                shell.DeleteSubKeyTree("APKToolGUI.Decompile", false);
                shell.DeleteSubKeyTree("APKToolGUI.Sign", false);
                shell.DeleteSubKeyTree("APKToolGUI.Zipalign", false);
                shell.DeleteSubKeyTree("APKToolGUI.Build", false);
                shell.DeleteSubKeyTree("APKToolGUI.Baksmali", false);
                shell.DeleteSubKeyTree("APKToolGUI.Smali", false);
                shell.Close();
            }
            catch (Exception exc)
            {
                return new Status(false, exc.Message);
            }

            return new Status(true, "Done!");
        }

        public class Status
        {
            public Status(bool result, string message)
            {
                Result = result;
                Message = message;
            }
            public bool Result { get; set; }
            public String Message { get; set; }
        }

        public enum Action
        {
            Create,
            Remove
        }
    }
}