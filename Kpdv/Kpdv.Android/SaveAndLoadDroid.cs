using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using Kpdv.Droid;
using Xamarin.Forms;
using Kpdv.Services;

[assembly: Dependency(typeof(SaveAndLoadDroid))]

namespace Kpdv.Droid
{
    public class SaveAndLoadDroid : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
             //salva o conteudo json local do app
            File.WriteAllText(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename), text);
        }

        public string LoadText(string filename)
        {
            var LocalFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename);
            if (File.Exists(LocalFile))
                return File.ReadAllText(LocalFile);
            return "";
        }   

        public bool DoesFileExiste(string filename)
        {
            var LocalFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), filename);
            return File.Exists(LocalFile);
        }


    }

}