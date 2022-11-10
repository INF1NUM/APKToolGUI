using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APKToolGUI.Handlers
{
    internal class ApkinfoControlEventHandlers
    {
        private static FormMain main;
        public ApkinfoControlEventHandlers(FormMain Main)
        {
            main = Main;
            main.selApkFileInfoBtn.Click += selApkFileInfoBtn_Click;
            main.psLinkBtn.Click += psLinkBtn_Click;
            main.apkComboLinkBtn.Click += apkComboLinkBtn_Click;
            main.apkPureLinkBtn.Click += apkPureLinkBtn_Click;
            main.apkGkLinkBtn.Click += apkGkLinkBtn_Click;
            main.apkSupportLinkBtn.Click += apkSupportLinkBtn_Click;
            main.apkSosLinkBtn.Click += apkSosLinkBtn_Click;
            main.apkMirrorLinkBtn.Click += apkMirrorLinkBtn_Click;
            main.apkAioLinkBtn.Click += apkAioLinkBtn_Click;
            main.apkDlLinkBtn.Click += apkDlLinkBtn_Click;
        }

        private void selApkFileInfoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    main.GetApkInfo(ofd.FileName);
                }
            }
        }

        private void psLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.PlayStoreLink);
        }

        private void apkComboLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkComboLink);
        }

        private void apkPureLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkPureLink);
        }

        private void apkGkLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkGkLink);
        }

        private void apkSupportLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkSupportLink);
        }

        private void apkSosLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkSosLink);
        }
        
        private void apkMirrorLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkMirrorLink);
        }
        
        private void apkAioLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkAioLink);
        }

        private void apkDlLinkBtn_Click(object sender, EventArgs e)
        {
            if (main.aapt != null)
                Process.Start(main.aapt.ApkDlLink);
        }
    }
}
