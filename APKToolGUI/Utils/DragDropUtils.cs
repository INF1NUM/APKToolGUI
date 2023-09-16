using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SaveToGameWpf.Logic.Utils
{
    public static class DragDropUtils
    {
        private static readonly string[] EmptyStrings = new string[0];

        public static string[] GetFilesDrop(this DragEventArgs args)
        {
            return (string[])args.Data.GetData(DataFormats.FileDrop) ?? EmptyStrings;
        }

        public static string[] GetFilesDrop(this DragEventArgs args, string ending)
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (string.IsNullOrEmpty(ending))
                return args.GetFilesDrop();

            return args.GetFilesDrop(it => it.EndsWith(ending, StringComparison.Ordinal));
        }

        public static string[] GetFilesDrop(this DragEventArgs args, Func<string, bool> filter)
        {
            var items = args.GetFilesDrop();

            if (items == null)
                return EmptyStrings;

            return filter == null ? items : items.Where(filter).ToArray();
        }

        public static void CheckDragEnter(this DragEventArgs e, params string[] extensions)
        {
            string[] files = e.GetFilesDrop();
            if (extensions == null && Directory.Exists(files[0]))
                e.Effect = DragDropEffects.Copy;
            else if (extensions != null && extensions.Any(ext => files[0].EndsWith(ext, StringComparison.Ordinal)))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        public static bool CheckDragOver(this DragEventArgs e, params string[] extensions)
        {
            string[] files = e.GetFilesDrop();
            if (extensions == null && Directory.Exists(files[0]))
            {
                e.Effect = DragDropEffects.Move;
                return true;
            }
            else if (files.Length == 1 && extensions.Any(ext => files[0].EndsWith(ext, StringComparison.Ordinal)))
            {
                e.Effect = DragDropEffects.Move;
                return true;
            }
            e.Effect = DragDropEffects.None;

            return false;
        }


        public static bool CheckManyDragOver(this DragEventArgs e, params string[] extensions)
        {
            string[] files = e.GetFilesDrop();

            if (extensions == null && Directory.Exists(files[0]))
            {
                e.Effect = DragDropEffects.Move;
                return true;
            }
            else if (extensions != null && extensions.Any(ext => files[0].EndsWith(ext, StringComparison.Ordinal)))
            {
                e.Effect = DragDropEffects.Move;
                return true;
            }
            e.Effect = DragDropEffects.None;

            return false;
        }

        public static bool DropOneByEnd(this DragEventArgs e, Action<string> onSuccess, params string[] extensions)
        {
            string[] files = e.GetFilesDrop();
            if (extensions == null && Directory.Exists(files[0]))
            {
                onSuccess(files[0]);
                return true;
            }
            else if (extensions.Any(ext => files[0].EndsWith(ext, StringComparison.Ordinal)))
            {
                onSuccess(files[0]);
                return true;
            }

            return false;
        }

        public static bool DropManyByEnd(this DragEventArgs e, Action<string[]> onSuccess, params string[] extensions)
        {
            foreach (string apk in extensions)
            {
                Debug.WriteLine(apk);
                string[] files = e.GetFilesDrop(apk);

                if (files.Length > 0)
                {
                    onSuccess(files);
                    return true;
                }
            }
            return false;
        }
    }
}
