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

            cboRCSetup.DataSource = RemoteCameraSetupInfo.Load();
            ucPictureViewer.Dock = DockStyle.Fill;
        }

        private void LoadPictures(object sender, EventArgs e)
        {
            if (sender is RadioButton && !((RadioButton)sender).Checked)
                return;

            if (cboRCSetup.SelectedItem is RemoteCameraSetupInfo)
            {
                PictureInfo.PictureSizes eSize = PictureInfo.PictureSizes.Thumbnail;
                if (rdoWeb.Checked)
                    eSize = PictureInfo.PictureSizes.WebResolution;
                else if (rdoFull.Checked)
                    eSize = PictureInfo.PictureSizes.FullResolution;

                RemoteCameraSetupInfo rc = cboRCSetup.SelectedItem as RemoteCameraSetupInfo;
                ucPictureViewer.UpdateViewer(rc, eSize, (int)valSize.Value);
            }
        }
    }
}
