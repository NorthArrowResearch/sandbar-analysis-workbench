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
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("nar")]
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
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int TableType_LookupTables {
            get {
                return ((int)(this["TableType_LookupTables"]));
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
        [global::System.Configuration.DefaultSettingValueAttribute("16")]
        public long TableType_ResultsTables {
            get {
                return ((long)(this["TableType_ResultsTables"]));
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
    }
}
