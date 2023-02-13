using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App3.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(App3.Droid.SQLite_Android))]
namespace App3.Droid
{
    public class SQLite_Android: ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
          
            var path = Path.Combine(documentsPath, sqliteFileName);

            var cn = new SQLiteConnection(path);

            return cn;
        }
    }
}