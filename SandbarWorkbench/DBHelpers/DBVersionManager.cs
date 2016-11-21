using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

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
            catch(Exception ex)
            {
                ex.Data["Database Path"] = sDatabasePath;
                throw;
            }

            return fiDatabase;
        }
    }
}
