using BaseProject.Bibliotecas.Interfaces;
using BaseProject.Droid.Services;
using Java.IO;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SaveService))]
namespace BaseProject.Droid.Services
{
    public class SaveService : ISave
    {
        public SaveService()
        {
        }

        public async void Save(byte[] bytes, string name)
        {
            var filename = Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath;  //System.IO.Path.Combine(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString());
            //Directory.CreateDirectory(filename);
            filename = System.IO.Path.Combine(filename, name);
            using (var fileOutputStream = new FileOutputStream(filename))
            {
                await fileOutputStream.WriteAsync(bytes);
            }
        }
    }
}