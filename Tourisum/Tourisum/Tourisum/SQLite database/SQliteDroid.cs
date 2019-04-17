using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace Tourisum.SQLite_database
{
    public class SQliteDroid : Isqlite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return  new SQLiteAsyncConnection(path);  
        }
    }
}
