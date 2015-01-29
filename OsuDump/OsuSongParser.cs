using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;

namespace OsuDump
{
    class OsuSongParser
    {
        public static List<OsuBundle> LoadFromCache(string file)
        {
            try
            {
                List<OsuBundle> listofa = new List<OsuBundle>();
                XmlSerializer formatter = new XmlSerializer(typeof(List<OsuBundle>));
                FileStream aFile = new FileStream(file, FileMode.Open);
                byte[] buffer = new byte[aFile.Length];
                aFile.Read(buffer, 0, (int)aFile.Length);
                aFile.Close();
                MemoryStream stream = new MemoryStream(buffer);
                listofa = (List<OsuBundle>)formatter.Deserialize(stream);

                for (int i = 0; i < listofa.Count; i++)
                {
                    for (int j = 0; j < listofa[i].Songs.Count; j++)
                    {
                        //denullify any collection data
                        listofa[i].Songs[j].CollectionsContainedIn = new List<string>();
                    }
                }

                return listofa;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Unable to load from osu parsed cache file.", "ERROR");
                return null;
            }
        }

        public static void Save(List<OsuBundle> listofa, string path)
        {
           try
            {
                for (int i = 0; i < listofa.Count; i++)
                {
                    for (int j = 0; j < listofa[i].Songs.Count; j++)
                    {
                        //Wipe any collection data
                        listofa[i].Songs[j].CollectionsContainedIn = new List<string>();
                    }
                }
                FileStream outFile = File.Create(path);
                XmlSerializer formatter = new XmlSerializer(typeof(List<OsuBundle>));
                formatter.Serialize(outFile, listofa);
                outFile.Close();
            }
           catch
            {
                 System.Windows.Forms.MessageBox.Show("Unable to save osu parsed cache file.", "ERROR");
                return;
            }
        }

        public static List<OsuBundle> ParseAllSongs(string SongsPath, List<OsuCollection> Collections)
        {
            List<OsuBundle> OsuBundles = new List<OsuBundle>();

            //Console.WriteLine("Reading Collections.db...");
            //Parse the collections database
            //List<OsuCollection> Collections = OsuCollectionReader.GetCollections(OsuPath + "\\collection.db");



            Console.WriteLine("Getting individual beatmap information...");
            //Get song directory
            DirectoryInfo SongDirectory = new DirectoryInfo(SongsPath + "\\Songs");

            //Get individual bundle directories
            DirectoryInfo[] BundleDirectories = SongDirectory.GetDirectories();
            for (int q = 0; q < BundleDirectories.Length; q++)
            {
                Console.WriteLine("Entering Osu Bundle Directory: " + BundleDirectories[q].Name);
                //Each file in the bundle folder
                FileInfo[] BundleFiles = BundleDirectories[q].GetFiles();

                OsuBundle CurrentBundle = new OsuBundle();

                for (int i = 0; i < BundleFiles.Length; i++)
                {
                    if (BundleFiles[i].Extension == ".osu")
                    {
                        Console.WriteLine("Parsing osu file: " + BundleFiles[i].Name);

                        OsuSong Song = new OsuSong();

                        Song.MapName = BundleFiles[i].Name;
                        Song.MapHash = BitConverter.ToString(MD5.Create().ComputeHash(File.OpenRead(BundleFiles[i].FullName))).ToLower().Replace("-", "");

                        Song.SongDirectory = BundleFiles[i].DirectoryName;

                        Song.SongName = GetValueFromMap(BundleFiles[i].FullName, "Title");
                        Song.Artist = GetValueFromMap(BundleFiles[i].FullName, "Artist");
                        Song.SongPath = BundleFiles[i].DirectoryName + "\\" + GetValueFromMap(BundleFiles[i].FullName, "AudioFilename");

                        Song.CollectionsContainedIn = new List<string>();

                        for (int x = 0; x < Collections.Count; x++)
                        {
                            for (int y = 0; y < Collections[x].GetHashCount(); y++)
                            {
                                if (Song.MapHash == Collections[x].GetHashByIndex(y))
                                {
                                    Song.CollectionsContainedIn.Add(Collections[x].Name);
                                    break;
                                }
                            }
                        }

                        CurrentBundle.Songs.Add(Song);
                        if (CurrentBundle.SongName == null) CurrentBundle.SongName = Song.SongName;

                        break;
                        //TEMP SPEEDUP - ONLY PARSE ONE BUNDLE FILE!
                    }
                }
                OsuBundles.Add(CurrentBundle);
            }
            return OsuBundles;
        }

        public static string GetValueFromMap(string FileName, string ValueName)
        {
            StreamReader Reader = new StreamReader(File.OpenRead(FileName));
            String Value = "";
            while (!Reader.EndOfStream)
            {
                string Line = Reader.ReadLine();
                if (Line.StartsWith(ValueName))
                {
                    Value = Line.Substring(Line.IndexOf(":") + 1);
                    if (Value.StartsWith(" ")) Value = Value.Substring(1);
                    break;
                }
            }

            Reader.Close();
            return Value;
        }
    }
}
