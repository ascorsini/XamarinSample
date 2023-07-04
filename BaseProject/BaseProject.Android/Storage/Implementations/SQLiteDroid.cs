using BaseProject.Bibliotecas;
using BaseProject.Droid.Storage.Implementations;
using BaseProject.Storage.Interface;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace BaseProject.Droid.Storage.Implementations
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteAsyncConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();

            string strName = Configuracao.NomeDatabase,
                   strDocumentsPath = Path.Combine(Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath, "db"),
                   strPath = Path.Combine(strDocumentsPath, strName);

            if (!Directory.Exists(strDocumentsPath))
                Directory.CreateDirectory(strDocumentsPath);

            return new SQLiteAsyncConnection(strPath);
        }
    }
}