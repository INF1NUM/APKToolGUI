using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace APKToolGUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(String[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (arg.Length > 0)
            {
                switch (arg[0])
                {
                    case "ccm":
                        ExplorerContextMenuMethod(ExplorerContextMenu.Action.Create);
                        break;
                    case "rcm":
                        ExplorerContextMenuMethod(ExplorerContextMenu.Action.Remove);
                        break;
                    case "b":
                        Application.Run(new FormBuild(arg));
                        break;
                    case "d":
                        Application.Run(new FormDecode(arg));
                        break;
                    default:
                        break;
                }
            }
            else
                if (FilesCheck() == true)
                    Application.Run(new FormMain());
        }

        public static void SetLanguage()
        {
            String settingsCulture = Properties.Settings.Default.Culture;

            if (settingsCulture.Equals("Auto"))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.InstalledUICulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            }
            else
            {
                System.Globalization.CultureInfo _settingsCulture = System.Globalization.CultureInfo.GetCultureInfo(settingsCulture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = _settingsCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = _settingsCulture;
            }
        }

        private static bool FilesCheck()
        {
            // проверка файлов
            List<String> missigFiles = MissingFilesCheck();
            if (missigFiles.Count > 0)
            {
                String files = Environment.NewLine;
                foreach (String file in missigFiles)
                {
                    files += file + Environment.NewLine;
                }
                MessageBox.Show("Отсутствуют необходимые файлы:" + files, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
                return false;
            }
            else
                return true;
        }

        private static List<String> MissingFilesCheck()
        {
            List<String> missingFiles = new List<string>();
            String[] fileList = new String[]{
                APKTOOL_PATH,
                ZIPALIGN_PATH,
                SIGNAPK_PATH,
                SIGNAPK_KEYPRIVATE,
                SIGNAPK_KEYPUBLIC};
            for (int i = 0; i < fileList.Length; i++)
                if (!System.IO.File.Exists(fileList[i]))
                    missingFiles.Add(System.IO.Path.GetFileName(fileList[i]));
            return missingFiles;
        }

        private static void ExplorerContextMenuMethod(ExplorerContextMenu.Action action)
        {
            ExplorerContextMenu.Status status = null;

            switch (action)
            {
                case ExplorerContextMenu.Action.Create:
                    status = ExplorerContextMenu.Create();
                    break;
                case ExplorerContextMenu.Action.Remove:
                    status = ExplorerContextMenu.Remove();
                    break;
                default:
                    return;
            }

            if (status.Result)
                MessageBox.Show(status.Message, Application.ProductName);
            else
                MessageBox.Show(status.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }

        public static string GetPortablePath(string path)
        {
            string startupPath = Application.StartupPath + System.IO.Path.DirectorySeparatorChar;
            if (path.Contains(startupPath))
                return path.Replace(startupPath, String.Empty);
            else
                return path;
        }

        private static readonly string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string APKTOOL_PATH { get { return appPath + @"\bin\apktool.jar"; } }
        public static string SIGNAPK_PATH { get { return  appPath + @"\bin\signapk.jar"; } }
        public static string SIGNAPK_KEYPRIVATE { get { return  appPath + @"\bin\testkey.pk8"; } }
        public static string SIGNAPK_KEYPUBLIC { get { return  appPath + @"\bin\testkey.x509.pem"; } }
        public static string ZIPALIGN_PATH { get { return appPath + @"\bin\zipalign.exe"; } }

        //public static readonly string APKTOOL_PATH = appPath + @"\bin\apktool.jar";
        //public static readonly string SIGNAPK_PATH = appPath + @"\bin\signapk.jar";
        //public static readonly string SIGNAPK_KEYPRIVATE = appPath + @"\bin\testkey.pk8";
        //public static readonly string SIGNAPK_KEYPUBLIC = appPath + @"\bin\testkey.x509.pem";
        //public static readonly string ZIPALIGN_PATH = appPath + @"\bin\zipalign.exe";
    }
}
