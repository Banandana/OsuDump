using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OsuDump
{
    class OsuExtractor
    {
        string OsuPath;
        List<OsuBundle> OsuBundles;
        public OsuExtractor(string OsuFolder, string OutFolder)
        {
            Console.WriteLine("Osu Folder is " + OsuFolder);
            OsuPath = OsuFolder;

            Console.WriteLine("Beginning parsing of Osu song bundles");
            OsuBundles = OsuSongParser.ParseAllSongs(Environment.CurrentDirectory);

            if (!Directory.Exists(OutFolder)) Directory.CreateDirectory(OutFolder);

            for (int i = 0; i < OsuBundles.Count; i++)
            {
                foreach (OsuSong Song in OsuBundles[i].Songs)
                {
                    for (int cv = 0; cv < Song.CollectionsContainedIn.Count; cv++)
                    {
                        if (!File.Exists(OutFolder + "//" + Song.CollectionsContainedIn[cv] + "//" + new FileInfo(Song.SongPath).Name))
                        {
                            if (!Directory.Exists(OutFolder + "//" + Song.CollectionsContainedIn[cv])) Directory.CreateDirectory(OutFolder + "//" + Song.CollectionsContainedIn[cv]);
                            Console.WriteLine("Adding song " + Song.SongName + " to collection folder " + Song.CollectionsContainedIn[cv]);
                            try
                            {
                                File.Copy(Song.SongPath, OutFolder + "//" + Song.CollectionsContainedIn[cv] + "//" + Song.SongName + " - " + Song.Artist + new FileInfo(Song.SongPath).Extension);
                                TagLib.File CurrentSongFile = TagLib.File.Create(OutFolder + "//" + Song.CollectionsContainedIn[cv] + "//" + Song.SongName + " - " + Song.Artist + new FileInfo(Song.SongPath).Extension);
                                if (CurrentSongFile.Tag.Title == null || CurrentSongFile.Tag.Title == "")
                                {
                                    CurrentSongFile.Tag.Title = Song.SongName;
                                    CurrentSongFile.Tag.AlbumArtists = new string[] { Song.Artist };
                                    CurrentSongFile.Save();
                                }
                            }
                            catch
                            {
                                //Don't do shit.
                            }
                        }
                    }
                    if (Song.CollectionsContainedIn.Count == 0 && !File.Exists(OutFolder + "//Unsorted//" + new FileInfo(Song.SongPath).Name))
                    {
                        if (!Directory.Exists(OutFolder + "//Unsorted")) Directory.CreateDirectory(OutFolder + "//Unsorted");
                        Console.WriteLine("Adding song " + Song.SongName + " to unsorted folder");
                        File.Copy(Song.SongPath, OutFolder + "//Unsorted//" + new FileInfo(Song.SongPath).Name);  
                    }
                }
            }
            Console.WriteLine("FINISHED!");
            Console.ReadLine();






        }

    }
}
