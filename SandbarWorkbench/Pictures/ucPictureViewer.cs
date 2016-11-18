using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandbarWorkbench.Pictures
{
    public partial class ucPictureViewer : UserControl
    {
        public ucPictureViewer()
        {
            InitializeComponent();
        }

        private void ucPictureViewer_Load(object sender, EventArgs e)
        {
            flwPanel.Dock = DockStyle.Fill;
            flwPanel.FlowDirection = FlowDirection.LeftToRight;
            flwPanel.AutoScroll = true;
        }

        public void UpdateViewer(RemoteCameraSetupInfo rc, PictureInfo.PictureSizes eSize, int nSize)
        {
            Cursor.Current = Cursors.WaitCursor;
            flwPanel.Controls.Clear();
            
            System.IO.DirectoryInfo diFolder = rc.GetPictureFolder(eSize);
            if (diFolder.Exists)
            {
                try
                {
                    foreach (string sFile in System.IO.Directory.GetFiles(diFolder.FullName, string.Format("*{0}", PictureInfo.FileSuffix)))
                    {
                        PictureInfo picInfo = PictureInfo.GetPictureInfo(rc.SiteCode, rc.BestPhotoTime);

                        PictureBox pic = new PictureBox();
                        pic.ImageLocation = sFile;
                        //pic.Size = new Size(nSize, nSize);
                        pic.SizeMode = PictureBoxSizeMode.AutoSize;
                        flwPanel.Controls.Add(pic);
                        pic.Tag = picInfo;
                        tTip.SetToolTip(pic, picInfo.SiteCodeFormatted);
                        pic.DoubleClick += this.PictureDoubleClicked;
                    }
                }
                catch (OutOfMemoryException ex)
                {
                    MessageBox.Show("Not all pictures were loaded.", "Out of Memory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        public void PictureDoubleClicked(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox picBox = (PictureBox)sender;
                if (picBox.Tag is PictureInfo)
                {
                    PictureInfo picInfo = (PictureInfo)picBox.Tag;
                    System.IO.FileInfo fiPicture = picInfo.BestImage;
                    if (fiPicture is System.IO.FileInfo && fiPicture.Exists)
                    {
                        System.Diagnostics.Process.Start(picBox.ImageLocation);
                    }
                }
            }
        }
    }
}
