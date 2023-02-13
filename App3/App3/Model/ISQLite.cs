using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
