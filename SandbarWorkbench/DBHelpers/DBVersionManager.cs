using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using DbUp;
using System.Reflection;
using DbUp.Engine;

namespace SandbarWorkbench.DBHelpers
{
    class DBVersionManager
    {
        /// <summary>
        /// Create a new database
        /// </summary>
        /// <param name="sDatabasePath">Full absolute database path to be created</param>
        /// <returns>FileInfo if successful or null if something goes wrong.</returns>
        /// <remarks>http://stackoverflow.com/questions/24178930/programmatically-create-sqlite-db-if-it-doesnt-exist
        /// The input database path is a string because it comes from a file open dialog.
        /// </remarks>
        public static System.IO.FileInfo CreateNewDatabase(string sDatabasePath)
        {
            System.IO.FileInfo fiDatabase = null;

            try
            {
                SQLiteConnection.CreateFile(sDatabasePath);
                fiDatabase = new System.IO.FileInfo(sDatabasePath);
            }
            catch (Exception ex)
            {
                ex.Data["Database Path"] = sDatabasePath;
                throw;
            }

            return fiDatabase;
        }

        /// <summary>
        /// Apply database migrations using DBUp
        /// </summary>
        /// <param name="dbCon">SQLite connection string</param>
        /// <param name="messages">Output messages</param>
        /// <remarks>Place database SQL files in the Scripts folder at the root of the project.
        /// Make sure the files are named in alpha numerical order in which they should be applied.
        /// Make sure that each file has its build action set to Embedded resource.
        /// https://dbup.readthedocs.io/en/latest/
        /// </remarks>
        /// <returns>True if successful. False if there's an error</returns>
        public static bool UpgradeDatabase(string dbCon, out string messages)
        {
            UpgradeEngine upgrader = DeployChanges.To
                    .SQLiteDatabase(dbCon)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .WithTransaction()
                    .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            messages = result.Successful ? "Database Migration Successful" : result.Error.Message;
            return result.Successful;
        }
    }
}
