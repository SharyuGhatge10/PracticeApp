using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tourisum.SQLite_database
{
    public interface Isqlite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
