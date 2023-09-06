using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.IO;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Shell;
using APKToolGUI.Languages;

namespace APKEasyTool
{
    public class TaskBarJumpList
    {
        private JumpList list;

        /// <summary>
        /// Creating a JumpList for the application
        /// </summary>
        /// <param name="windowHandle"></param>
        public TaskBarJumpList(IntPtr windowHandle)
        {
            list = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, windowHandle);
            list.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
            BuildList();
        }

        public void AddToRecent(string destination)
        {
            //Call JumpList.AddToRecent(destination); because of bug
            JumpList.AddToRecent(destination);
            list.Refresh();
        }

        public void AddTasks(string titleValue, string args)
        {
            JumpListLink jumpListLink = new JumpListLink(Assembly.GetEntryAssembly().Location, titleValue);
            jumpListLink.IconReference = new IconReference(Assembly.GetEntryAssembly().Location, 3);
            jumpListLink.Arguments = args;

            list.AddUserTasks(jumpListLink);
        }

        /// <summary>
        /// Builds the Jumplist
        /// </summary>
        private void BuildList()
        {
            JumpListCustomCategory userActionsCategory = new JumpListCustomCategory("Actions");

            AddTasks(Language.OpenDecFolder, "opendecfolder");
            AddTasks(Language.OpenComFolder, "opencomfolder");

            list.Refresh();
        }
    }
}
