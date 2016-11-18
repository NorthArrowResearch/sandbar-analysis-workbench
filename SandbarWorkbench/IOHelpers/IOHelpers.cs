using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.IOHelpers
{
    class IOHelpers
    {
        public static System.IO.DirectoryInfo GetValidFolder(string sFolder)
        {
            if (!string.IsNullOrEmpty(sFolder) && System.IO.Directory.Exists(sFolder))
                return new System.IO.DirectoryInfo(sFolder);
            else
                return null;
        }

        public static System.IO.FileInfo GetValidFile(string sFile)
        {
            if (!string.IsNullOrEmpty(sFile) && System.IO.File.Exists(sFile))
                return new System.IO.FileInfo(sFile);
            else
                return null;
        }

        public static bool FillTextBoxFolder(string sFolder, ref System.Windows.Forms.TextBox txt)
        {
            System.IO.DirectoryInfo diFolder = GetValidFolder(sFolder);
            if (diFolder is System.IO.DirectoryInfo)
            {
                txt.Text = diFolder.FullName;
                return true;
            }
            else
            {
                txt.Text = string.Empty;
                return false;
            }
        }

        public static bool FillTextBoxFile(string sFile, ref System.Windows.Forms.TextBox txt)
        {
            System.IO.FileInfo fiFile = GetValidFile(sFile);
            if (fiFile is System.IO.FileInfo)
            {
                txt.Text = fiFile.FullName;
                return true;
            }
            else
            {
                txt.Text = string.Empty;
                return false;
            }
        }

        public static System.IO.DirectoryInfo BrowseOpenFolder(string sDescription, string sDefaultPath)
        {
            FolderBrowserDialog frm = new FolderBrowserDialog();
            frm.Description = sDescription;

            if (!string.IsNullOrEmpty(sDefaultPath)
                && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(sDefaultPath)))
            {
                frm.SelectedPath = sDefaultPath;
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                return new System.IO.DirectoryInfo(frm.SelectedPath);
            }
            else
            {
                return null;
            }
        }


        public static System.IO.FileInfo BrowseOpenFile(string sTitle, string sFilter, string sDefaultPath)
        {
            OpenFileDialog frm = new OpenFileDialog();
            frm.Title = sTitle;
            frm.CheckFileExists = true;
            frm.Filter = sFilter;
            frm.AddExtension = true;

            if (!string.IsNullOrEmpty(sDefaultPath)
                && System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(sDefaultPath)))
            {
                frm.InitialDirectory = (System.IO.Path.GetDirectoryName(sDefaultPath));
                if (System.IO.File.Exists(sDefaultPath))
                    frm.FileName = System.IO.Path.GetFileNameWithoutExtension(sDefaultPath);
            }

            if (frm.ShowDialog() == DialogResult.OK)
            {
                return new System.IO.FileInfo(frm.FileName);
            }
            else
            {
                return null;
            }
        }

        public static bool BrowseFillTextBoxFolder(string sTitle, ref TextBox txt, bool bClearOnCancel)
        {
            System.IO.DirectoryInfo fiResult = BrowseOpenFolder(sTitle, txt.Text);
            if (fiResult is System.IO.DirectoryInfo && fiResult.Exists)
            {
                txt.Text = fiResult.FullName;
                return true;
            }
            else
            {
                if (bClearOnCancel)
                    txt.Text = string.Empty;
                return false;
            }
        }

        public static bool BrowseFillTextBoxFile(string sTitle, string sFilter, ref TextBox txt, bool bClearOnCancel)
        {
            System.IO.FileInfo fiResult = BrowseOpenFile(sTitle, sFilter, txt.Text);
            if (fiResult is System.IO.FileInfo && fiResult.Exists)
            {
                txt.Text = fiResult.FullName;
                return true;
            }
            else
            {
                if (bClearOnCancel)
                    txt.Text = string.Empty;
                return false;
            }
        }

        public static bool ValidateFolderTextbox(string sDescription, ref TextBox txt, Button btnBrowse = null)
        {
            if (!string.IsNullOrEmpty(txt.Text) && System.IO.Directory.Exists(txt.Text))
            {
                return true;
            }
            else
            {
                MessageBox.Show(string.Format("Please choose a valid folder for the {0}.", sDescription), "Invalid Folder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Select();
                return false;
            }
        }

        public static bool ValidateFileTextbox(string sDescription, ref TextBox txt, Button btnBrowse = null)
        {
            if (!string.IsNullOrEmpty(txt.Text) && System.IO.File.Exists(txt.Text))
            {
                return true;
            }
            else;
            {
                MessageBox.Show(string.Format("Please choose a valid file for the {0}.", sDescription), "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBrowse.Select();
                return false;
            }
        }
    }
}
