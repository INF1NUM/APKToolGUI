using APKToolGUI.Languages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APKToolGUI.Handlers
{
    internal class MenuItemHandlers
    {
        private static FormMain main;
        public MenuItemHandlers(FormMain Main)
        {
            main = Main;
            main.saveLogToFileToolStripMenuItem.Click += saveLogItem_Click;
            main.settingsToolStripMenuItem.Click += menuItemSettings_Click;
            main.exitToolStripMenuItem.Click += menuItemExit_Click;
            main.openTempFolderToolStripMenuItem.Click += openTempFolderToolStripMenuItem_Click;
            main.checkForUpdateToolStripMenuItem.Click += menuItemCheckUpdate_Click;
            main.aboutToolStripMenuItem.Click += menuItemAbout_Click;
            main.apktoolIssuesToolStripMenuItem.Click += apktoolIssuesLinkItem_Click;
            main.baksmaliIssuesToolStripMenuItem.Click += baksmaliIssuesLinkItem_Click;
            main.reportAnIsuueToolStripMenuItem.Click += reportAnIsuueToolStripMenuItem_Click;

        }
        private void saveLogItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = "APK Tool GUI logs";
                sfd.Filter = Language.TextFile + " (*.txt)|*.txt";
                sfd.FilterIndex = 2;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, main.logTxtBox.Text);
                }
            }
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings();
            frm.ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openTempFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Program.TEMP_PATH))
                Process.Start("explorer.exe", Program.TEMP_PATH);
        }

        private void menuItemCheckUpdate_Click(object sender, EventArgs e)
        {
            main.updateCheker.CheckAsync();
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            FormAboutBox frm = new FormAboutBox();
            frm.ShowDialog();
        }

        private void apktoolIssuesLinkItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iBotPeaches/Apktool/issues?q=is%3Aissue");
        }

        private void baksmaliIssuesLinkItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JesusFreke/smali/issues?q=is%3Aissue");
        }

        private void reportAnIsuueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AndnixSH/APKToolGUI/issues/new/choose");
        }
    }
}
