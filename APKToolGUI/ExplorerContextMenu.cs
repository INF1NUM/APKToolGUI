using System;
using Microsoft.Win32;

namespace APKToolGUI
{
    public class ExplorerContextMenu
    {
        public static Status Create()
        {
            string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (IsAdmin())
            {
                if (Environment.OSVersion.Version >= new Version("6.0.0.0")) // Vista и новее
                {
                    return CreateVistaAndLater(executablePath);
                }
                else if (Environment.OSVersion.Version < new Version("6.0.0.0") && Environment.OSVersion.Version >= new Version("5.1.0.0"))
                {
                    return CreateXP(executablePath);
                }
                else
                    return new Status(false, "Unsupported OS");
            }
            else
                return new Status(false, "Administrator rights are required");
        }

        public static Status Remove()
        {
            if (Environment.OSVersion.Version >= new Version("6.0.0.0")) // Vista и новее
            {
                return RemoveVistaAndLater();
            }
            else
            {
                if (Environment.OSVersion.Version < new Version("6.0.0.0") && Environment.OSVersion.Version >= new Version("5.1.0.0"))
                {
                    return RemoveXP();
                }
                else
                    return new Status(false, "Unsupported OS");
            }
        }

        public static bool IsAdmin()
        {
            System.Security.Principal.WindowsIdentity id = System.Security.Principal.WindowsIdentity.GetCurrent();
            System.Security.Principal.WindowsPrincipal p = new System.Security.Principal.WindowsPrincipal(id);

            return p.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
        }

        private static Status CreateVistaAndLater(string executablePath)
        {
            try
            {
                #region Add context menu  to registry

                RegistryKey apkToolGUIFolderShell = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey("APKToolGUI", RegistryKeyPermissionCheck.ReadWriteSubTree);
                apkToolGUIFolderShell.SetValue("Icon", executablePath);
                apkToolGUIFolderShell.SetValue("MUIVerb", "APKToolGUI");
                apkToolGUIFolderShell.SetValue("SubCommands", "APKToolGUI.Build");
                apkToolGUIFolderShell.Close();

                Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey(".apk", RegistryKeyPermissionCheck.ReadWriteSubTree).CreateSubKey("DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", executablePath, RegistryValueKind.ExpandString);
                RegistryKey shellAPK = Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.CreateSubKey).CreateSubKey("shell", RegistryKeyPermissionCheck.ReadWriteSubTree).CreateSubKey("APKToolGUI", RegistryKeyPermissionCheck.ReadWriteSubTree);
                shellAPK.SetValue("Icon", "\"" + executablePath + "\"");
                shellAPK.SetValue("MUIVerb", "APKToolGUI");
                shellAPK.SetValue("SubCommands", "APKToolGUI.Decompile;APKToolGUI.InstallFramework;APKToolGUI.Sign");
                shellAPK.Close();

                #endregion

                #region Add command to registry

                RegistryKey shell;
                if (Environment.Is64BitOperatingSystem)
                    shell = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                else
                    shell = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\CommandStore\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);

                RegistryKey decompile = shell.CreateSubKey("APKToolGUI.Decompile", RegistryKeyPermissionCheck.ReadWriteSubTree);
                decompile.SetValue("", Language.Decode, RegistryValueKind.String);
                decompile.SetValue("Icon", executablePath, RegistryValueKind.String);
                decompile.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"d\" \"%1\"");
                decompile.Close();

                RegistryKey installFramework = shell.CreateSubKey("APKToolGUI.InstallFramework", RegistryKeyPermissionCheck.ReadWriteSubTree);
                installFramework.SetValue("", Language.InstallFramework, RegistryValueKind.String);
                installFramework.SetValue("Icon", executablePath, RegistryValueKind.String);
                installFramework.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"if\" \"%1\"");
                installFramework.Close();

                RegistryKey sign = shell.CreateSubKey("APKToolGUI.Sign", RegistryKeyPermissionCheck.ReadWriteSubTree);
                sign.SetValue("", Language.Sign, RegistryValueKind.String);
                sign.SetValue("Icon", executablePath, RegistryValueKind.String);
                sign.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"sign\" \"%1\"");
                sign.Close();

                RegistryKey build = shell.CreateSubKey("APKToolGUI.Build", RegistryKeyPermissionCheck.ReadWriteSubTree);
                build.SetValue("", Language.Build, RegistryValueKind.String);
                build.SetValue("Icon", executablePath, RegistryValueKind.String);
                build.CreateSubKey("command").SetValue("", "\"" + executablePath + "\" \"b\" \"%1\"", RegistryValueKind.String);
                build.Close();

                shell.Close();

                #endregion
            }
            catch (Exception exc)
            {
                return new Status(false, exc.Message);
            }

            return new Status(true, "Done!");
        }

        private static Status CreateXP(string executablePath)
        {
            try
            {
                RegistryKey folderShell = Registry.ClassesRoot.OpenSubKey(@"Directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey("APKToolGUI.Build", RegistryKeyPermissionCheck.ReadWriteSubTree);
                folderShell.SetValue("Icon", executablePath);
                folderShell.SetValue("MUIVerb", Language.Build);
                folderShell.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"b\" \"%1\"", RegistryValueKind.String);
                folderShell.Close();

                RegistryKey apk = Registry.ClassesRoot.OpenSubKey("SystemFileAssociations", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).CreateSubKey(".apk", RegistryKeyPermissionCheck.ReadWriteSubTree);
                apk.CreateSubKey("DefaultIcon", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", executablePath, RegistryValueKind.ExpandString);
                RegistryKey shell = apk.CreateSubKey("shell", RegistryKeyPermissionCheck.ReadWriteSubTree);

                RegistryKey decode = shell.CreateSubKey("APKToolGUI.Decode", RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey installFramework = shell.CreateSubKey("APKToolGUI.InstallFramework", RegistryKeyPermissionCheck.ReadWriteSubTree);
                RegistryKey sign = shell.CreateSubKey("APKToolGUI.Sign", RegistryKeyPermissionCheck.ReadWriteSubTree);

                decode.SetValue("Icon", executablePath);
                decode.SetValue("MUIVerb", Language.Decode);
                decode.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"d\" \"%1\"");
                decode.Close();

                installFramework.SetValue("Icon", executablePath);
                installFramework.SetValue("MUIVerb", Language.InstallFramework);
                installFramework.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"if\" \"%1\"");
                installFramework.Close();

                sign.SetValue("Icon", executablePath);
                sign.SetValue("MUIVerb", Language.Sign);
                sign.CreateSubKey("command", RegistryKeyPermissionCheck.ReadWriteSubTree).SetValue("", "\"" + executablePath + "\" \"sign\" \"%1\"");
                sign.Close();

                shell.Close();
                apk.Close();
            }
            catch (Exception exc)
            {
                return new Status(false, exc.Message);
            }

            return new Status(true, "Done!");
        }

        private static Status RemoveVistaAndLater()
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
                shell.DeleteSubKeyTree("APKToolGUI.InstallFramework", false);
                shell.DeleteSubKeyTree("APKToolGUI.Sign", false);
                shell.DeleteSubKeyTree("APKToolGUI.Build", false);
                shell.Close();
            }
            catch (Exception exc)
            {
                return new Status(false, exc.Message);
            }

            return new Status(true, "Done!");
        }

        private static Status RemoveXP()
        {
            try
            {
                Registry.ClassesRoot.OpenSubKey(@"Directory\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("APKToolGUI.Build", false);

                Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("DefaultIcon", false);

                Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("APKToolGUI.Decode", false);
                Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("APKToolGUI.InstallFramework", false);
                Registry.ClassesRoot.OpenSubKey(@"SystemFileAssociations\.apk\shell", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl).DeleteSubKeyTree("APKToolGUI.Sign", false);
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