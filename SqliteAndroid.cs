using System;
using System.IO;
using Android.OS;
using PoultaryLatam.DataService.SQLite.Interface;
using PoultaryLatam.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]
namespace PoultaryLatam.Droid
{
    public class SqliteAndroid : ISqlFilePath
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}