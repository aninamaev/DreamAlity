using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Meaning.Droid;
using Meaning.Infrastructure.Database;
using SQLite;

[assembly:Xamarin.Forms.Dependency(typeof(SqliteAndroid))]
namespace Meaning.Droid
{
    public class SqliteAndroid:ISqLite
    {
        public SQLiteConnection GetConnection()
        {
            var docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(docPath, "MeanDb.db3");
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}