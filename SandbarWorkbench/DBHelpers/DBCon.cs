using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SandbarWorkbench
{
    public sealed class DBCon
    {
        #region Singleton Implementation

        // Singleton pattern take from version #3 on this link
        // http://csharpindepth.com/Articles/General/Singleton.aspx

        private static DBCon instance;
        private static readonly object padlock = new object();
        private static System.IO.FileInfo m_fiDatabasePath;
        private const string m_sRootConnectionStringLocal = "Data Source={0};Version=3;Pooling=True;Max Pool Size=100";
        private const string m_sRootConnectionStringMaster = "server={0};uid={1};pwd={2};database={3};Port={4}";

        public static DBCon Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBCon();
                    }
                    return instance;
                }
            }
        }

        #endregion

//        public static string ConnectionStringMaster
//        {
//            get
//            {
//                string sConString = string.Empty;
//                if (!RetrieveDeveloperCredentials(out sConString))
//                {
//                    sConString = string.Format(m_sRootConnectionStringMaster,
//                        SandbarWorkbench.Properties.Settings.Default.MasterServer,
//                        SandbarWorkbench.Properties.Settings.Default.MasterUser,
//                        SandbarWorkbench.Properties.Settings.Default.MasterPassword,
//                        SandbarWorkbench.Properties.Settings.Default.MasterDatabase,
//                        SandbarWorkbench.Properties.Settings.Default.MasterPort);
//                }

//                //System.Diagnostics.Debug.Print("Master DB Con: {0}", sConString);
//                return sConString;
//            }
//        }

//        private static bool RetrieveDeveloperCredentials(out string sConString)
//        {
//            sConString = string.Empty;

//            // Release build never uses the developer database credentials file
//#if (!DEBUG)
//  return false;
//#endif
//            bool bSuccessful = false;
//            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
//            string sDeveloperCredentials = System.IO.Path.Combine(dir.Parent.Parent.Parent.FullName, "master_database_credentials.xml");
//            if (System.IO.File.Exists(sDeveloperCredentials))
//            {
//                XmlDocument xmlDoc = new XmlDocument();

//                try
//                {
//                    xmlDoc.Load(sDeveloperCredentials);
//                    XmlNode nodCredentials = xmlDoc.SelectSingleNode("master_database_credentials");
//                    if (nodCredentials is XmlNode)
//                    {
//                        string sServer = string.Empty;
//                        XmlNode nodServer = nodCredentials.SelectSingleNode("server");
//                        if (nodServer is XmlNode)
//                            sServer = nodServer.InnerText;

//                        string sDatabase = string.Empty;
//                        XmlNode nodDatabase = nodCredentials.SelectSingleNode("database");
//                        if (nodDatabase is XmlNode)
//                            sDatabase = nodDatabase.InnerText;

//                        string sUserName = string.Empty;
//                        XmlNode nodUserName = nodCredentials.SelectSingleNode("username");
//                        if (nodUserName is XmlNode)
//                            sUserName = nodUserName.InnerText;

//                        string sPassword = string.Empty;
//                        XmlNode nodPassword = nodCredentials.SelectSingleNode("password");
//                        if (nodPassword is XmlNode)
//                            sPassword = nodPassword.InnerText;

//                        string sPort = string.Empty;
//                        XmlNode nodPort = nodCredentials.SelectSingleNode("port");
//                        if (nodPort is XmlNode)
//                            sPort = nodPort.InnerText;
//                        else
//                            sPort = SandbarWorkbench.Properties.Settings.Default.MasterPort;

//                        if (string.IsNullOrEmpty(sServer) || string.IsNullOrEmpty(sDatabase) ||
//                            string.IsNullOrEmpty(sUserName) || string.IsNullOrEmpty(sPassword))
//                        {
//                            System.Diagnostics.Debug.Print("One or more empty values in the developer master database credential XML file.");
//                        }
//                        else
//                        {
//                            sConString = string.Format(m_sRootConnectionStringMaster, sServer, sUserName, sPassword, sDatabase, sPort);
//                            bSuccessful = true;
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    System.Diagnostics.Debug.Print("Error loading developer master database credential XML file.");
//                }
//            }
//            else
//            {
//                System.Diagnostics.Debug.Print("Developer master database credential file missing. Using software settings.");
//            }

//            return bSuccessful;
//        }

        public static string ConnectionStringLocal
        {
            get
            {
                if (m_fiDatabasePath is System.IO.FileInfo)
                    return string.Format(m_sRootConnectionStringLocal, m_fiDatabasePath.FullName);
                else
                    return string.Empty;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || !System.IO.File.Exists(value))
                    m_fiDatabasePath = null;
                else
                    m_fiDatabasePath = new System.IO.FileInfo(value);
            }
        }

        public static void CloseDatabase()
        {
            ConnectionStringLocal = string.Empty;
        }

        public static string DatabasePath
        {
            get
            {
                if (m_fiDatabasePath is System.IO.FileInfo)
                    return m_fiDatabasePath.FullName;
                else
                    return string.Empty;
            }
        }

        private DBCon()
        {
            // deliberately private and empty constructor.
        }
    }
}