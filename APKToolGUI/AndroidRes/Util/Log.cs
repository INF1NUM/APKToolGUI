using APKToolGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Media;

namespace APKSMerger.Util
{
    /// <summary>
    /// simple logging wrapper class
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// should very verbose logs (Log.vv) be written?
        /// </summary>
        public static bool LogVeryVerbose { get; set; } = false;

        /// <summary>
        /// should verbose logs (Log.v) be written?
        /// </summary>
        public static bool LogVerbose { get; set; } = true;

        /// <summary>
        /// should debug logs (Log.d) be written?
        /// </summary>
        public static bool LogDebug { get; set; } = true;

        #region direct logs
        /// <summary>
        /// log message with level VERY VERBOSE (may be disabled)
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void vv(string s)
        {
            if (!LogVeryVerbose) return;
            FormMain.Instance.ToLog(ApktoolEventType.None, s);
        }

        /// <summary>
        /// log message with level VERBOSE (may be disabled)
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void v(string s)
        {
            if (!LogVerbose) return;
            FormMain.Instance.ToLog(ApktoolEventType.None, s);
        }

        /// <summary>
        /// log message with level DEBUG (may be disabled)
        /// </summary>
        /// <param name="s">the string to log</param>
        public static void d(string s)
        {
            if (!LogDebug) return;
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

        /// <summary>
        /// start a new async log session
        /// </summary>
        /// <returns></returns>
        public static AsyncLogSession StartAsync()
        {
            return new AsyncLogSession();
        }

        /// <summary>
        /// writes a direct log message
        /// </summary>
        /// <param name="s">the string to log</param>
        /// <param name="color">color to log in, null is default</param>
        static void WriteLogDirect(string s, ConsoleColor? color = null)
        {
            //set color
            ConsoleColor iColor = Console.ForegroundColor;
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
            }

            //write log
            Console.WriteLine(s);

            //restore color
            if (color.HasValue)
            {
                Console.ForegroundColor = iColor;
            }
        }

        /// <summary>
        /// async log sesssion
        /// </summary>
        public class AsyncLogSession : IDisposable
        {
            /// <summary>
            /// lock object to ensure only one object commits at a time
            /// </summary>
            static readonly object _CommitLock = new object();

            /// <summary>
            /// Tag to include when logging
            /// </summary>
            Stack<string> tags = new Stack<string>();

            /// <summary>
            /// contains all pending log entries
            /// </summary>
            Queue<string> pending = new Queue<string>();

            #region log functions
            /// <summary>
            /// log message with level VERY VERBOSE (may be disabled)
            /// </summary>
            /// <param name="s">the string to log</param>
            public void vv(string s)
            {
                if (!LogVeryVerbose) return;

                EnqueueMessage($"[VV]{s}");
            }

            /// <summary>
            /// log message with level VERBOSE (may be disabled)
            /// </summary>
            /// <param name="s">the string to log</param>
            public void v(string s)
            {
                if (!LogVerbose) return;

                EnqueueMessage($"[V]{s}");
            }

            /// <summary>
            /// log message with level DEBUG (may be disabled)
            /// </summary>
            /// <param name="s">the string to log</param>
            public void d(string s)
            {
                if (!LogDebug) return;

                EnqueueMessage($"[D]{s}");
            }

            /// <summary>
            /// log message with level INFO
            /// </summary>
            /// <param name="s">the string to log</param>
            public void i(string s)
            {
                EnqueueMessage($"[I]{s}");
            }

            /// <summary>
            /// log message with level WARNING
            /// </summary>
            /// <param name="s">the string to log</param>
            public void w(string s)
            {
                EnqueueMessage($"[W]{s}");
            }

            /// <summary>
            /// log message with level ERROR
            /// </summary>
            /// <param name="s">the string to log</param>
            public void e(string s)
            {
                EnqueueMessage($"[E]{s}");
            }
            #endregion

            /// <summary>
            /// enqueue a message in the message queue
            /// </summary>
            /// <param name="s">the message to enqueue</param>
            void EnqueueMessage(string s)
            {
                pending.Enqueue($"{GetTag()}:{s}");
            }

            /// <summary>
            /// push a tag onto the tags stack
            /// </summary>
            /// <param name="t">the tag to push</param>
            public void PushTag(string t)
            {
                tags.Push(t);
            }

            /// <summary>
            /// pop the last tag of the tags stack
            /// </summary>
            public void PopTag()
            {
                //  tags.TryPop(out _);
            }

            /// <summary>
            /// get the current tag
            /// </summary>
            /// <returns>current tag, or string.Empty if no tag</returns>
            public string GetTag()
            {
                string tag;
                // if (!tags.TryPeek(out tag))
                tag = string.Empty;

                return tag;
            }

            /// <summary>
            /// commit all pending log entries
            /// </summary>
            public void Commit()
            {
                lock (_CommitLock)
                {
                    while (pending.Count > 0)
                    {
                        WriteLogDirect(pending.Dequeue());
                    }
                }
            }

            /// <summary>
            /// same as calling .Commit(). used for using() syntax
            /// </summary>
            public void Dispose()
            {
                Commit();
            }
        }
    }
}
