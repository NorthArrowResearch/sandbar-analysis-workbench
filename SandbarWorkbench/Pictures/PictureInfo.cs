using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace SandbarWorkbench.Pictures
{
    public class PictureInfo : RemoteCameras.RemoteCameraBase
    {
        public const string FileSuffix = ".jpg";

        public enum PictureSizes
        {
            Thumbnail,
            WebResolution,
            FullResolution
        }

        public System.IO.FileInfo ThumbailPath { get; internal set; }
        public System.IO.FileInfo FullResPath { get; internal set; }
        public System.IO.FileInfo WebResPath { get; internal set; }
        //public DateTime DateTimeTaken { get; internal set; }

        public string Caption
        {
            get
            {
                return System.IO.Path.GetFileNameWithoutExtension(BestImagePath);
            }
        }

        public PictureInfo(string sRemoteCameraCode, System.IO.FileInfo fiThumb, System.IO.FileInfo fiFullRes, System.IO.FileInfo fiWebRes) : base(sRemoteCameraCode)
        {
            ThumbailPath = fiThumb;
            FullResPath = fiFullRes;
            WebResPath = fiWebRes;
        }

        public System.IO.FileInfo BestImage
        {
            get
            {
                if (FullResPath is System.IO.FileInfo && FullResPath.Exists)
                    return FullResPath;
                else if (WebResPath is System.IO.FileInfo && WebResPath.Exists)
                    return WebResPath;
                else if (ThumbailPath is System.IO.FileInfo && ThumbailPath.Exists)
                    return ThumbailPath;
                else
                    return null;
            }
        }

        public string BestImagePath
        {
            get
            {
                System.IO.FileInfo fiPath = BestImage;
                if (fiPath is System.IO.FileInfo)
                    return fiPath.FullName;
                else
                    return string.Empty;
            }
        }

        public System.IO.FileInfo SmallestImage
        {
            get
            {
                if (ThumbailPath is System.IO.FileInfo && ThumbailPath.Exists)
                    return ThumbailPath;
                else if (WebResPath is System.IO.FileInfo && WebResPath.Exists)
                    return WebResPath;
                else if (FullResPath is System.IO.FileInfo && FullResPath.Exists)
                    return FullResPath;
                else
                    return null;
            }
        }

        public string SmallestImagePath
        {
            get
            {
                System.IO.FileInfo fiPath = SmallestImage;
                if (fiPath is System.IO.FileInfo)
                    return fiPath.FullName;
                else
                    return string.Empty;
            }
        }

        public static PictureInfo GetPictureInfo(string sRemoteCameraCode, string sBestTime)
        {
            PictureInfo picResult = null;

            if (!string.IsNullOrEmpty(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras)
                && System.IO.Directory.Exists(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras))
            {
                if (!sRemoteCameraCode.ToLower().StartsWith("rc"))
                    sRemoteCameraCode = String.Format("RC{0}", sRemoteCameraCode);

                string sThumbsFolder = System.IO.Path.Combine(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras, "Photos_Thumb_Res", sRemoteCameraCode);
                string sFullResFoldr = System.IO.Path.Combine(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras, "Photos_Full_Res", sRemoteCameraCode);
                string sWebResFolder = System.IO.Path.Combine(SandbarWorkbench.Properties.Settings.Default.Folder_RemoteCameras, "Photos_Web_Res", sRemoteCameraCode);

                // Do a search for the best thumbnail. But for the full and web res, attempt to 
                // simply find the matching file name to the thumnail file (if it was successful)
                // but search as a last resort.
                System.IO.FileInfo fiThumb = SearchForClosestFile(sThumbsFolder, sBestTime, 100, 1);
                System.IO.FileInfo fiFullRes = CheckThenSearchForClosestFile(sFullResFoldr, sBestTime, fiThumb, string.Empty);
                System.IO.FileInfo fiWebRes = CheckThenSearchForClosestFile(sWebResFolder, sBestTime, fiThumb, "web");

                if (fiThumb is System.IO.FileInfo || fiFullRes is System.IO.FileInfo || fiWebRes is System.IO.FileInfo)
                {
                    picResult = new PictureInfo(sRemoteCameraCode, fiThumb, fiFullRes, fiWebRes);
                }
            }

            return picResult;
        }

        /// <summary>
        /// Check for a file in the specified folder that matches the candidate file name or search if it doesn't exist
        /// </summary>
        /// <param name="sFolder">The target folder where to look for files</param>
        /// <param name="sBestTime">The best time used only if a search is required</param>
        /// <param name="fiCandidateFile">The full file path to an existing file that posesses the </param>
        /// <param name="sSuffix">The desired file name suffix (e.g. "web" or "thumb" or "" for full res) of the target file</param>
        /// <returns></returns>
        private static System.IO.FileInfo CheckThenSearchForClosestFile(string sFolder, string sBestTime, System.IO.FileInfo fiCandidateFile, string sSuffix)
        {
            System.IO.FileInfo fiResult = null;
            bool bNeedToSearch = true;
            if (fiCandidateFile is System.IO.FileInfo)
            {
                // Extract the root part of the candidate file name (e.g. "RC0025L_YYYYMMDD_HHMM"). 
                // This will strip the suffix "_thumb" or "_web" depending on the candidate file resolution
                Match maRoot = Regex.Match(System.IO.Path.GetFileName(fiCandidateFile.FullName), "(^.*_[0-9]{8}_[0-9]{4})");
                System.Diagnostics.Debug.Assert(maRoot is Match, "All resolutions should match this Regex");
                string sCandidateFileName = string.Format("{0}{1}{2}", maRoot.Groups[1], string.IsNullOrEmpty(sSuffix) ? "" : "_", sSuffix);

                // Try and look for the same file name in the target folder
                string sFilePath = System.IO.Path.Combine(sFolder, sCandidateFileName);
                sFilePath = System.IO.Path.ChangeExtension(sFilePath, "jpg");

                if (System.IO.File.Exists(sFilePath))
                {
                    fiResult = new System.IO.FileInfo(sFilePath);
                    bNeedToSearch = false;
                }
            }

            if (bNeedToSearch)
                fiResult = SearchForClosestFile(sFolder, sBestTime, 100, 1);

            return fiResult;
        }

        private static System.IO.FileInfo SearchForClosestFile(string sFolder, string sBestTime, int nBlockSize, int nPage)
        {
            System.IO.FileInfo fiResult = null;

            if (System.IO.Directory.Exists(sFolder))
            {
                Nullable<DateTime> dtTarget = new Nullable<DateTime>();

                // Attempt to build the target date time object using todays date but the best time of day from the argument
                if (!string.IsNullOrEmpty(sBestTime))
                {
                    Match gBestTime = Regex.Match(sBestTime, "([0-9]{2})([0-9]{2})");
                    if (gBestTime is Match && gBestTime.Groups.Count == 3)
                    {
                        dtTarget = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(gBestTime.Groups[1].Value), int.Parse(gBestTime.Groups[2].Value), 0);
                    }
                }

                string sClosestFile = string.Empty;
                //Nullable<DateTimeOffset> dtoClosest = new Nullable<DateTimeOffset>();
                Nullable<long> nClosestDifference = new Nullable<long>();

                string sSearch = string.Format("*{0}", FileSuffix);
                string[] arrFilePaths = System.IO.Directory.GetFiles(sFolder, sSearch, System.IO.SearchOption.TopDirectoryOnly);
                int nSearch = 0;
                while (nSearch < nBlockSize && nSearch < arrFilePaths.Length)
                {
                    string sFilePath = arrFilePaths[nSearch];
                    Match theMatch = Regex.Match(System.IO.Path.GetFileNameWithoutExtension(sFilePath), "_([0-9]{8})_([0-9]{4})");
                    if (theMatch is Match && theMatch.Groups.Count == 3)
                    {
                        DateTime picDate;
                        if (DateTime.TryParseExact(theMatch.Groups[1].Value + theMatch.Groups[2].Value, "yyyyMMddhhmm", new CultureInfo("en-US"), DateTimeStyles.None, out picDate))
                        {
                            if (dtTarget.HasValue)
                            {
                                if (nClosestDifference.HasValue)
                                {
                                    long nDiff = (dtTarget.Value - picDate).Ticks;
                                    if (nClosestDifference.Value > nDiff)
                                    {
                                        // This file is closer than any other file.
                                        nClosestDifference = nDiff;
                                        sClosestFile = sFilePath;
                                    }
                                }
                                else
                                {
                                    // First time through. The first file is the closest.
                                    sClosestFile = sFilePath;
                                    nClosestDifference = dtTarget.Value.Subtract(picDate).Ticks;
                                }
                            }
                            else
                            {
                                // There is no target date. Simply grab the first file and get out of loop.
                                sClosestFile = sFilePath;
                                break;
                            }
                        }
                    }
                    nSearch++;
                }
         
                if (!string.IsNullOrEmpty(sClosestFile))
                {
                    fiResult = new System.IO.FileInfo(sClosestFile);
                }
            }

            return fiResult;
        }
    }
}
