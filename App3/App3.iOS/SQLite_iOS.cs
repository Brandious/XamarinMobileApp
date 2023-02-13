using App3.Model;
using Foundation;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(App3.iOS.SQLite_iOS))]
namespace App3.iOS
{
    public class SQLite_iOS: ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");

            var path = Path.Combine(libraryPath, sqliteFileName);

            var cn = new SQLiteConnection(path);

            return cn;
        }
    }
}