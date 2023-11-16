﻿using APKToolGUI.Languages;
using System;
using System.ComponentModel;
using System.Net;

namespace APKToolGUI
{
    class UpdateChecker
    {
        public UpdateChecker(string url, Version currentVersion)
        {
            currentVer = currentVersion;
            Url = url;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        private BackgroundWorker backgroundWorker;
        private Version currentVer;
        public string Url { get; set; }

        public event RunWorkerCompletedEventHandler Completed;
        //public event EventHandler Error;

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Completed(this, e);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Version latestVersion = null;
            string changelog = null;
            try
            {
                latestVersion = GetVersion();
                changelog = GetChangelog();
            }
            catch (Exception exc)
            {
                e.Result = new Result(State.Error, exc.Message, (bool)e.Argument);
            }
            if (latestVersion != null)
            {
                if (CompareVersion(latestVersion))
                {
                    e.Result = new Result(State.NeedUpdate, latestVersion.ToString(), (bool)e.Argument, changelog);
                }
                else
                    e.Result = new Result(State.NoUpdate, null, (bool)e.Argument);
            }
            else
                e.Result = new Result(State.Error, Language.ErrorVersionParsing, (bool)e.Argument);
        }

        private bool CompareVersion(Version latestVersion)
        {
            if (latestVersion > currentVer)
                return true;
            else
                return false;
        }

        public void CheckAsync(bool silently = false)
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync(silently);
        }

        private Version GetVersion()
        {
            string versionString;
            using (WebClient webClient = new WebClient())
            {
                versionString = webClient.DownloadString(Url);
            }

            Version version = new Version();
            if (Version.TryParse(versionString, out version))
            {
                return version;
            }
            else
                return null;
        }

        private string GetChangelog()
        {
            string changelog;
            using (WebClient webClient = new WebClient())
            {
                changelog = webClient.DownloadString("https://repo.andnixsh.com/tools/APKToolGUI/changelog.txt");
            }

             return changelog;
        }

        public enum State
        {
            NoUpdate,
            NeedUpdate,
            Error
        }

        public class Result
        {
            public Result(State state, string message, bool silently, string changelog = null)
            {
                State = state;
                Message = message;
                Silently = silently;
                Changelog = changelog;
            }
            public State State { get; private set; }
            public string Message { get; private set; }
            public bool Silently { get; private set; }
            public string Changelog { get; private set; }
        }
    }
}
