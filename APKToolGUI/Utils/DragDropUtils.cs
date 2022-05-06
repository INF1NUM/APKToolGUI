using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
        public static void CheckDragEnter(this DragEventArgs e, string extensions)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                var ext = Path.GetExtension(file);
                if (!String.IsNullOrEmpty(extensions) && ext.Equals(extensions))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
                else if (String.IsNullOrEmpty(extensions) && File.Exists(Path.Combine(file, "AndroidManifest.xml")))
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }
            e.Effect = DragDropEffects.None;
        }

        public static bool CheckDragOver(this DragEventArgs e, string extensions)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return false;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                var ext = Path.GetExtension(file);
                if (!String.IsNullOrEmpty(extensions) && ext.Equals(extensions))
                {
                    e.Effect = DragDropEffects.Copy;
                    return true;
                }
                else if (String.IsNullOrEmpty(extensions) && File.Exists(Path.Combine(file, "AndroidManifest.xml")))
                {
                    e.Effect = DragDropEffects.Copy;
                    return true;
                }
            }
            return false;
        }

        public static bool CheckManyDragOver(this DragEventArgs e, params string[] extensions)
        {
            string[] files = e.GetFilesDrop();
            if (extensions.Any(ext => files[0].EndsWith(ext, StringComparison.Ordinal)))
            {
                e.Effect = DragDropEffects.Move;
                return true;
            }
            e.Effect = DragDropEffects.None;

            return false;
        }

        public static bool DropOneByEnd(this DragEventArgs e, string ext, Action<string> onSuccess)
        {
            string[] files = e.GetFilesDrop(ext);

            if (files.Length == 1)
            {
                onSuccess(files[0]);

                return true;
            }

            return false;
        }

        public static string DropOneByEnd(this DragEventArgs e, string ext)
        {
            string[] files = e.GetFilesDrop(ext);

            if (files.Length == 1)
                return files[0];

            return null;
        }

        public static void DropManyByEnd(this DragEventArgs e, string ext, Action<string[]> onSuccess)
        {
            string[] files = e.GetFilesDrop(ext);

            if (files.Length > 0)
                onSuccess(files);
        }

        public static string[] DropManyByEnd(this DragEventArgs e, string ext)
        {
            string[] files = e.GetFilesDrop(ext);

            if (files.Length > 0)
                return files;

            return null;
        }
    }
}
