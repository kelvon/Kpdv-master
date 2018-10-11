using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using Kpdv.iOS;
using Kpdv.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SaveAndLoadIOS))]

namespace Kpdv.iOS
{
    public class SaveAndLoadIOS : ISaveAndLoad
    {
        public void SaveText(string filename, string text)
        {
            //salva o conteudo json local do app
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename), text);
        }

        public string LoadText(string filename)
        {
            var LocalFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
            if (File.Exists(LocalFile))
                return File.ReadAllText(LocalFile);
            return "";
        }

        public bool DoesFileExiste(string filename)
        {
            var LocalFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
            return File.Exists(LocalFile);
        }


    }
}