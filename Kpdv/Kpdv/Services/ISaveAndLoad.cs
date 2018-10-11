using System;
using System.Collections.Generic;
using System.Text;

namespace Kpdv.Services
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
        bool DoesFileExiste(string filename);


    }
}
