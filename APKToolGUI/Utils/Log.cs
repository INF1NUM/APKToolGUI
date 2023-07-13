using APKToolGUI;
using APKToolGUI.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;

namespace APKToolGUI.Utils
{
    /// <summary>
    /// simple logging wrapper class
    /// </summary>
    public static class Log
    {
        #region direct logs
        /// <summary>
        /// log message with level VERY VERBOSE (may be disabled)
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void vv(string s)
        {
            if (!Settings.Default.DebugMode) return;
            FormMain.Instance.ToLog(ApktoolEventType.None, s);
        }

        /// <summary>
        /// log message with level VERBOSE (may be disabled)
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void v(string s)
        {
            if (!Settings.Default.DebugMode) return;
            FormMain.Instance.ToLog(ApktoolEventType.None, s);
        }

        /// <summary>
        /// log message with level DEBUG (may be disabled)
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void d(string s)
        {
            if (!Settings.Default.DebugMode) return;
            FormMain.Instance.ToLog(ApktoolEventType.None, s);
        }

        /// <summary>
        /// log message with level INFO
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void i(string s)
        {
            FormMain.Instance.ToLog(ApktoolEventType.Infomation, s);
        }

        /// <summary>
        /// log message with level WARNING
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void w(string s)
        {
            FormMain.Instance.ToLog(ApktoolEventType.Warning, s);
        }

        /// <summary>
        /// log message with level ERROR
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void e(string s)
        {
            FormMain.Instance.ToLog(ApktoolEventType.Error, s);
        }
        #endregion
    }
}
