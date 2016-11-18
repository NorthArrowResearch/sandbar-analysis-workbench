using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SandbarWorkbench.Pictures
{
    public partial class frmPictureViewer : Form
    {
        public frmPictureViewer()
        {
            InitializeComponent();
        }

        private void frmPictureViewer_Load(object sender, EventArgs e)
        {
            // Fix bug where the form icon uses the Visual Studio default when launched maximized
            // http://stackoverflow.com/questions/888865/problem-with-icon-on-creating-new-maximized-mdi-child-form-in-net
            this.Icon = (Icon)Icon.Clone();

            flwPanel.Dock = DockStyle.Fill;
            flwPanel.FlowDirection = FlowDirection.LeftToRight;
            flwPanel.AutoScroll = true;

            cboRCSetup.DataSource = RemoteCameraSetupInfo.Load();
        }

        private void LoadPictures(object sender, EventArgs e)
        {
            //imgList.Images.Clear();
            //lstPictures.Items.Clear();

            flwPanel.Controls.Clear();

            if (sender is RadioButton && !((RadioButton)sender).Checked)
                return;

            if (string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras) ||
        !System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras))
            {
                return;
            }

            //imgList.ImageSize = new Size((int)valSize.Value, (int)valSize.Value);

            if (cboRCSetup.SelectedItem is RemoteCameraSetupInfo)
            {
                RemoteCameraSetupInfo rc = cboRCSetup.SelectedItem as RemoteCameraSetupInfo;
                string sFolder = string.Empty;

                if (rdoFull.Checked)
                    sFolder = rc.FullResFolder;
                else if (rdoWeb.Checked)
                    sFolder = rc.WebResFolder;
                else
                    sFolder = rc.ThumbsFolder;

                int i = 0;
                if (!string.IsNullOrEmpty(sFolder) && System.IO.Directory.Exists(sFolder))
                {
                    try
                    {
                        foreach (string sFile in System.IO.Directory.GetFiles(sFolder, string.Format("*{0}", PictureInfo.FileSuffix)))
                        {
                            PictureBox pic = new PictureBox();
                            pic.ImageLocation = sFile;
                            pic.Size = new Size((int)valSize.Value, (int)valSize.Value);
                            pic.SizeMode = PictureBoxSizeMode.AutoSize;
                            flwPanel.Controls.Add(pic);
                            pic.Tag = sFile;

                            //imgList.Images.Add(System.Drawing.Image.FromFile(sFile));
                            //ListViewItem l = lstPictures.Items.Add(System.IO.Path.GetFileNameWithoutExtension(sFile), i);
                            //l.Tag = sFile;
                            //i += 1;
                        }
                    }
                    catch (OutOfMemoryException ex)
                    {
                        MessageBox.Show("Not all pictures were loaded.", "Out of Memory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        //private void lstPictures_DoubleClick(object sender, EventArgs e)
        //{
        //    if (flow.SelectedItems.Count > 0)
        //    {
        //        System.Diagnostics.Process.Start(lstPictures.SelectedItems[0].Tag.ToString());
        //    }
        //}
    }
}
