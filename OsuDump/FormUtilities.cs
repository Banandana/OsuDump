using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace OsuDump
{
    static class FormUtilities
    {
        public static string BrowseDirectory()
        {
            FolderBrowserDialog Dialog = new FolderBrowserDialog();
            Dialog.ShowDialog();
            if (Dialog.SelectedPath == "") return "";
            if (!Directory.Exists(Dialog.SelectedPath)) return "";

            return Dialog.SelectedPath;
        }

        public static string BrowseFile()
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            Dialog.ShowDialog();
            if (Dialog.FileName == "") return "";
            if (!File.Exists(Dialog.FileName)) return "";

            return Dialog.FileName;
        }

        public static string SaveFile()
        {
            SaveFileDialog Dialog = new SaveFileDialog();
            Dialog.ShowDialog();
            if (Dialog.FileName == "") return "";
            if (!File.Exists(Dialog.FileName)) return "";

            return Dialog.FileName;
        }
    }
}
