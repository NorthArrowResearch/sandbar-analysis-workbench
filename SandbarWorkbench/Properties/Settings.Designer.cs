﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SandbarWorkbench.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.8.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string LastDatabasePath {
            get {
                return ((string)(this["LastDatabasePath"]));
            }
            set {
                this["LastDatabasePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("00000000-0000-0000-0000-000000000000")]
        public global::System.Guid AWSCloudWatchGUID {
            get {
                return ((global::System.Guid)(this["AWSCloudWatchGUID"]));
            }
            set {
                this["AWSCloudWatchGUID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AWSLoggingEnabled {
            get {
                return ((bool)(this["AWSLoggingEnabled"]));
            }
            set {
                this["AWSLoggingEnabled"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("us-west-2")]
        public string AWSRegion {
            get {
                return ((string)(this["AWSRegion"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("NARApps-SandbarWorkbench")]
        public string AWSGroupName {
            get {
                return ((string)(this["AWSGroupName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AKIAIM7D6NQSGCW37YDQ")]
        public string AWSKey {
            get {
                return ((string)(this["AWSKey"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("hSd6jwqQUs8Bk2AxC+hXV/CNhY3J2KP2gmIesC5/")]
        public string AWSSecret {
            get {
                return ((string)(this["AWSSecret"]));
            }
            set {
                this["AWSSecret"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool LoadLastDatabase {
            get {
                return ((bool)(this["LoadLastDatabase"]));
            }
            set {
                this["LoadLastDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int StartupView {
            get {
                return ((int)(this["StartupView"]));
            }
            set {
                this["StartupView"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int ListID_SectionTypes {
            get {
                return ((int)(this["ListID_SectionTypes"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("00000000-0000-0000-0000-000000000000")]
        public global::System.Guid InstallationHash {
            get {
                return ((global::System.Guid)(this["InstallationHash"]));
            }
            set {
                this["InstallationHash"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mysql.northarrowresearch.com")]
        public string MasterServer {
            get {
                return ((string)(this["MasterServer"]));
            }
            set {
                this["MasterServer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("workbench_user")]
        public string MasterUser {
            get {
                return ((string)(this["MasterUser"]));
            }
            set {
                this["MasterUser"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string MasterPassword {
            get {
                return ((string)(this["MasterPassword"]));
            }
            set {
                this["MasterPassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SandbarData")]
        public string MasterDatabase {
            get {
                return ((string)(this["MasterDatabase"]));
            }
            set {
                this["MasterDatabase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\GCMRC\\PHYSICAL\\Sandbars\\Topo_Data\\corgrids")]
        public string Folder_SandbarTopoData {
            get {
                return ((string)(this["Folder_SandbarTopoData"]));
            }
            set {
                this["Folder_SandbarTopoData"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SiteCode5")]
        public string SandbarIdentification {
            get {
                return ((string)(this["SandbarIdentification"]));
            }
            set {
                this["SandbarIdentification"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal Default_InputCellSize {
            get {
                return ((decimal)(this["Default_InputCellSize"]));
            }
            set {
                this["Default_InputCellSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.25")]
        public decimal Default_OutputCellSize {
            get {
                return ((decimal)(this["Default_OutputCellSize"]));
            }
            set {
                this["Default_OutputCellSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("21")]
        public long Default_Interpolation {
            get {
                return ((long)(this["Default_Interpolation"]));
            }
            set {
                this["Default_Interpolation"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9")]
        public long ListID_InstrumentTypes {
            get {
                return ((long)(this["ListID_InstrumentTypes"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dd MMM yyy")]
        public string DateFormat_AuditFields {
            get {
                return ((string)(this["DateFormat_AuditFields"]));
            }
            set {
                this["DateFormat_AuditFields"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dd MMM yyy")]
        public string DateFormat_TripDates {
            get {
                return ((string)(this["DateFormat_TripDates"]));
            }
            set {
                this["DateFormat_TripDates"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("dd MMM yyy")]
        public string DateFormat_SurveyDates {
            get {
                return ((string)(this["DateFormat_SurveyDates"]));
            }
            set {
                this["DateFormat_SurveyDates"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int MaxTripLength {
            get {
                return ((int)(this["MaxTripLength"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"PROJCS[""NAD_1983_2011_StatePlane_Arizona_Central_FIPS_0202"",GEOGCS[""GCS_NAD_1983_2011"",DATUM[""NAD_1983_2011"",SPHEROID[""GRS_1980"",6378137.0,298.257222101]],PRIMEM[""Greenwich"",0.0],UNIT[""Degree"",0.0174532925199433]],PROJECTION[""Transverse_Mercator""],PARAMETER[""false_easting"",213360.0],PARAMETER[""false_northing"",0.0],PARAMETER[""central_meridian"",-111.9166666666667],PARAMETER[""scale_factor"",0.9999],PARAMETER[""latitude_of_origin"",31.0],UNIT[""Meter"",1.0]]")]
        public string SpatialReference {
            get {
                return ((string)(this["SpatialReference"]));
            }
            set {
                this["SpatialReference"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public long ListID_RiverBanks {
            get {
                return ((long)(this["ListID_RiverBanks"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("7")]
        public long ListID_CameraCardTypes {
            get {
                return ((long)(this["ListID_CameraCardTypes"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\GCMRC\\PHYSICAL\\Sandbars\\RemoteCameras")]
        public string Folder_RemoteCameras {
            get {
                return ((string)(this["Folder_RemoteCameras"]));
            }
            set {
                this["Folder_RemoteCameras"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\Temp\\GCMRC")]
        public string Folder_SandbarAnalysisResults {
            get {
                return ((string)(this["Folder_SandbarAnalysisResults"]));
            }
            set {
                this["Folder_SandbarAnalysisResults"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\GCMRC\\PHYSICAL\\Sandbars\\Topo_Data\\corgrids\\Sandbar_comp_bnds\\ComputationExtent" +
            "s.shp")]
        public string CompExtents_ShapeFile {
            get {
                return ((string)(this["CompExtents_ShapeFile"]));
            }
            set {
                this["CompExtents_ShapeFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\OSGeo4W64\\bin\\gdalwarp.exe")]
        public string GDALWarp {
            get {
                return ((string)(this["GDALWarp"]));
            }
            set {
                this["GDALWarp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.1")]
        public decimal ElevationIncrement {
            get {
                return ((decimal)(this["ElevationIncrement"]));
            }
            set {
                this["ElevationIncrement"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("8000")]
        public decimal BenchmarkStage {
            get {
                return ((decimal)(this["BenchmarkStage"]));
            }
            set {
                this["BenchmarkStage"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12")]
        public long RunTypeID_UserGenerated {
            get {
                return ((long)(this["RunTypeID_UserGenerated"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\Code\\sandbar-analysis\\sandbar-analysis\\main.py")]
        public string SandbarAnalysisMainPy {
            get {
                return ((string)(this["SandbarAnalysisMainPy"]));
            }
            set {
                this["SandbarAnalysisMainPy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3306")]
        public string MasterPort {
            get {
                return ((string)(this["MasterPort"]));
            }
            set {
                this["MasterPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"set OSGEO4W_ROOT=C:\\OSGeo4W64
call C:\OSGeo4W64\bin\o4w_env.bat
set PATH=%PATH%;%OSGEO4W_ROOT%\apps\qgis\bin
set PYTHONPATH=%PYTHONPATH%;%OSGEO4W_ROOT%\apps\qgis\python
set PYTHONPATH=%PYTHONPATH%;%OSGEO4W_ROOT%\apps\Python27\Lib\site-packages
set QGIS_PREFIX_PATH=%OSGEO4W_ROOT%\apps\qgis")]
        public string PythonConfig {
            get {
                return ((string)(this["PythonConfig"]));
            }
            set {
                this["PythonConfig"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool BackupRequiredOnClose {
            get {
                return ((bool)(this["BackupRequiredOnClose"]));
            }
            set {
                this["BackupRequiredOnClose"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string BackupDatabaseFolder {
            get {
                return ((string)(this["BackupDatabaseFolder"]));
            }
            set {
                this["BackupDatabaseFolder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("D:\\GCMRC\\PHYSICAL\\Sandbars\\Topo_Data")]
        public string CampsitesFolder {
            get {
                return ((string)(this["CampsitesFolder"]));
            }
            set {
                this["CampsitesFolder"] = value;
            }
        }
    }
}
