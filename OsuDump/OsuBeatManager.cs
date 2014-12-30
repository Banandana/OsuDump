using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OsuDump
{
    class OsuBeatManager
    {
        public static List<OsuBundle> GetAllMapBundles(string OsuSongsPath)
        {
            List<OsuBundle> Bundles = new List<OsuBundle>();

            DirectoryInfo MainFolder = new DirectoryInfo(OsuSongsPath);
            DirectoryInfo[] SongFolders = MainFolder.GetDirectories();
            for (int j = 0; j < SongFolders.Count(); j++)
            {
                OsuBundle B = new OsuBundle();
                //B.CreateFromFolder(SongFolders[j].FullName);
                Bundles.Add(B);
            }

            return Bundles;
        }
    }
}