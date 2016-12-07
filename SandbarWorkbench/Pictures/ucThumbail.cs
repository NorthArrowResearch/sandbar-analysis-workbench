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
    public partial class ucThumbail : UserControl
    {
        private BackgroundWorker bgw;

        private PictureInfo picInfo { get; set; }
        private string SiteCode { get; set; }
        private string BestPhotoTime { get; set; }

        public ucThumbail()
        {
            InitializeComponent();
            bgw = new BackgroundWorker();
            bgw.DoWork += backgroundWorker1_DoWork;
            bgw.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        public void UpdateThumbnail(string sSiteCode, string sBestPhotoTime)
        {
            picThumbnail.Visible = false;
            picThumbnail.ImageLocation = string.Empty;
            picThumbnail.Tag = null;
            lblCaption.Visible = false;

            if (!bgw.IsBusy)
            {
                if (!string.IsNullOrEmpty(sSiteCode))
                {
                    SiteCode = sSiteCode;
                    BestPhotoTime = sBestPhotoTime;
                    bgw.RunWorkerAsync();
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            picInfo = PictureInfo.GetPictureInfo(SiteCode, BestPhotoTime);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (picInfo is Pictures.PictureInfo)
                {
                    picThumbnail.ImageLocation = picInfo.SmallestImagePath;
                    picThumbnail.Visible = true;
                    picThumbnail.Tag = picInfo;
                    lblCaption.Text = System.IO.Path.GetFileNameWithoutExtension(picThumbnail.ImageLocation);
                    lblCaption.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }

        private void picThumbnail_DoubleClick(object sender, EventArgs e)
        {
            if (picThumbnail.Visible)
            {
                if (!string.IsNullOrEmpty(picThumbnail.ImageLocation) && System.IO.File.Exists(picThumbnail.ImageLocation))
                {
                    if (picThumbnail.Tag is Pictures.PictureInfo)
                    {
                        Pictures.PictureInfo picBig = (Pictures.PictureInfo)picThumbnail.Tag;
                        System.Diagnostics.Process.Start(picBig.BestImagePath);
                    }
                }
            }

        }
    }
}
