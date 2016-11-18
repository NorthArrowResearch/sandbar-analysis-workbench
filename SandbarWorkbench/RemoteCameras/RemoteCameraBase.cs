using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandbarWorkbench.RemoteCameras
{
    public class RemoteCameraBase
    {
        public string SiteCode { get; internal set; }

        public string ThumbsFolder { get { return GetContextualFolder("Photos_Thumb_Res"); } }
        public string FullResFolder { get { return GetContextualFolder("Photos_Full_Res"); } }
        public string WebResFolder { get { return GetContextualFolder("Photos_Web_Res"); } }

        public string SiteCodeFormatted
        {
            get
            {
                if (SiteCode.ToLower().StartsWith("rc"))
                    return SiteCode;
                else
                    return string.Format("RC{0}", SiteCode);
            }
        }

        public override string ToString()
        {
            return SiteCode;
        }

        public RemoteCameraBase(string sSiteCode)
        {
            SiteCode = sSiteCode;
        }

        private string GetContextualFolder(string sImageSizeFolder)
        {
            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras) &&
                               System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras))
            {
                return System.IO.Path.Combine(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras, sImageSizeFolder, SiteCodeFormatted);
            }
            else
                return string.Empty;
        }
    }
}
