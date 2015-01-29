using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
namespace OsuDump
{
    public partial class Extractor : Form
    {
        bool shouldStop, shouldStopExporting;
        List<OsuCollection> OsuCollections;
        List<OsuBundle> OsuBundles;

        Dictionary<int, string> ListIndexes;

        public Extractor()
        {
            InitializeComponent();
            ListIndexes = new Dictionary<int, string>();
            OsuBundles = new List<OsuBundle>();

            shouldStopExporting = false;
            shouldStop = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void CollectionsBrowseButton_Click(object sender, EventArgs e)
        {
            string path = FormUtilities.BrowseFile();
            if (path != "") CollectionsPathBox.Text = path;
        }

        private void SongsBrowseButton_Click(object sender, EventArgs e)
        {
            string path = FormUtilities.BrowseDirectory();
            if (path != "") SongsPathBox.Text = path;
        }

        private void OutputBrowseButton_Click(object sender, EventArgs e)
        {
            string path = FormUtilities.BrowseDirectory();
            if (path != "") OutputPathBox.Text = path;
        }

        private void CacheBrowseButton_Click(object sender, EventArgs e)
        {
            string path = FormUtilities.BrowseFile();
            if (path != "") CachePathBox.Text = path;
        }

        private void OpenDataButton_Click(object sender, EventArgs e)
        {
            Log("Checking user-selected directories.");
            if (CollectionsPathBox.Text == "" || !File.Exists(CollectionsPathBox.Text))
            {
                MessageBox.Show("Error: Collections.db filepath not valid.", "ERROR");
                return;
            }
            if (SongsPathBox.Text == "" || !Directory.Exists(SongsPathBox.Text))
            {
                MessageBox.Show("Error: Song directory path not valid.", "ERROR");
                return;
            }
            if (OsuCollections == null)
            {
                Log("User directories checked. Opening Osu Collections.db file...");
                OsuCollections = OsuCollectionReader.GetCollections(CollectionsPathBox.Text);
                CollectionsCountLabel.Text = "Number of Collections: " + OsuCollections.Count;

                Log("Building hash count...");
                int hashcount = 0;
                for (int i = 0; i < OsuCollections.Count; i++)
                {
                    hashcount += OsuCollections[i].GetHashCount();
                }

                HashCountLabel.Text = "Total Song Hashes: " + hashcount;


                Log("Building collections list...");
                CollectionsList.Items.Clear();
                CollectionsList.Items.Add("[Unsorted]");
                ListIndexes.Add(0, "Unsorted");
                for (int i = 0; i < OsuCollections.Count; i++)
                {
                    //CollectionsList.Items.Add(OsuCollections[i].Name);
                    ListIndexes.Add(
                        CollectionsList.Items.Add(
                            OsuCollections[i].Name + " - " + OsuCollections[i].GetHashCount() + " songs"),
                                OsuCollections[i].Name);
                }

                CollectionsList.Enabled = true;

                Log("All files loaded successfully!");
                Log("Select the collections to dump to the output directory.");
            }
       
        }

        public void Log(string value)
        {

            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { value });
                return;
            }
            LogBox.AppendText(value + Environment.NewLine);
        }

        public void ThreadOff()
        {

            if (InvokeRequired)
            {
                this.Invoke(new Action(ThreadOff));
                return;
            }
            StopExportButton.Enabled = false;
            ExportSongsButton.Enabled = true;
        }

        private void LoadCacheButton_Click(object sender, EventArgs e)
        {
            if (CachePathBox.Text == "" || !File.Exists(CachePathBox.Text))
            {
                MessageBox.Show("Error: Cache filepath not valid.", "ERROR");
                return;
            }
            CachelessParse.Enabled = false;
            StopParseButton.Enabled = false;
            OsuBundles = OsuSongParser.LoadFromCache(CachePathBox.Text);
            if (OsuBundles == null)
            {
                CachelessParse.Enabled = true;
                StopParseButton.Enabled = false;
                return;
            }
            int songcount = 0;

            for (int i = 0; i < OsuBundles.Count; i++)
            {
                songcount += OsuBundles[i].Songs.Count;
            }

            CacheCount.Text = "Songs Cached: " + songcount;

            PopulateCollectionData();
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

        void PopulateCollectionData()
        {
            Log("Finished parsing osu song data. Beginning collections comparison...");

            List<OsuCollection> CollectionClone = OsuCollections;

            for (int x = 0; x < CollectionClone.Count; x++)
            {
                for (int y = 0; y < CollectionClone[x].GetHashCount(); y++)
                {
                    for (int i = 0; i < OsuBundles.Count; i++)
                    {
                        for (int q = 0; q < OsuBundles[i].Songs.Count; q++)
                        {
                            if (OsuBundles[i].Songs[q].MapHash == CollectionClone[x].GetHashByIndex(y))
                            {
                                Log("Adding song " + OsuBundles[i].SongName + " to collection " + CollectionClone[x].Name);
                                OsuBundles[i].Songs[q].CollectionsContainedIn.Add(CollectionClone[x].Name);
                                CollectionClone[x].RemoveHash(CollectionClone[x].GetHashByIndex(y));
                                if (shouldStop) { Log("Parsing has been interrupted"); StopParseButton.Enabled = false; return; };
                                break;
                            }
                        }
                    }
                }
            }
        }

        void Parse()
        {
            DirectoryInfo SongDirectory = new DirectoryInfo(SongsPathBox.Text);

            //Create the collection list
            if (OsuCollections != null)
            {
                PopulateCollectionData();
            }

            //Get individual bundle directories
            DirectoryInfo[] BundleDirectories = SongDirectory.GetDirectories();
            for (int q = 0; q < BundleDirectories.Length; q++)
            {
                if (shouldStop) { Log("Parsing has been interrupted"); StopParseButton.Enabled = false; return; };
                Log("Entering Osu Bundle Directory: " + BundleDirectories[q].Name);
                //Each file in the bundle folder
                FileInfo[] BundleFiles = BundleDirectories[q].GetFiles();

                OsuBundle CurrentBundle = new OsuBundle();

                for (int i = 0; i < BundleFiles.Length; i++)
                {
                    if (shouldStop) { Log("Parsing has been interrupted"); StopParseButton.Enabled = false; return; };
                    if (BundleFiles[i].Extension == ".osu")
                    {
                        Log("Parsing osu file: " + BundleFiles[i].Name);

                        OsuSong Song = new OsuSong();

                        Song.MapName = BundleFiles[i].Name;
                        Song.MapHash = BitConverter.ToString(MD5.Create().ComputeHash(File.OpenRead(BundleFiles[i].FullName))).ToLower().Replace("-", "");

                        Song.SongDirectory = BundleFiles[i].Directory.Name;

                        Song.SongName = GetValueFromMap(BundleFiles[i].FullName, "Title");
                        Song.Artist = GetValueFromMap(BundleFiles[i].FullName, "Artist");
                        Song.SongPath = Song.SongDirectory + "\\" + GetValueFromMap(BundleFiles[i].FullName, "AudioFilename");

                        Song.CollectionsContainedIn = new List<string>();

                        //Go through each collection
                        foreach (OsuCollection collection in OsuCollections)
                        { 
                            //Go through each hash in the collection
                            foreach (string hash in collection.Hashes)
                            {
                                //If the song hash matches any hash, associate eachother
                                if (Song.MapHash == hash)
                                {
                                    //Add the collection name to the list of collections the song is contained in
                                    if (!Song.CollectionsContainedIn.Contains(collection.Name))
                                        Song.CollectionsContainedIn.Add(collection.Name);
                                }
                            }
                        }

                        CurrentBundle.Songs.Add(Song);
                        if (CurrentBundle.SongName == null) CurrentBundle.SongName = Song.SongName;
                    }
                }
                OsuBundles.Add(CurrentBundle);
            }

            Log("Finished parsing all data");
        }

        void Export()
        {
            Log("Beginning song export process!");
            int copycount = 0; int failcount = 0;
            //Iterate the list of checkbox items
            for (int i = 0; i < ListIndexes.Count; i++)
            {
                //If it's checked...
                if (CollectionsList.GetItemChecked(i))
                {
                    //Find the collection corresponding to the checked box
                    for (int j = 0; j < OsuCollections.Count; j++)
                    {
                        if (OsuCollections[j].Name == ListIndexes[i])
                        {
                            //Iterate all songs/bundles and copy the song IF IT IS IN THE COLLECTION to the specified folder
                            for (int k = 0; k < OsuBundles.Count; k++)
                            {
                                for (int l = 0; l < OsuBundles[k].Songs.Count; l++)
                                {
                                    for (int m = 0; m < OsuBundles[k].Songs[l].CollectionsContainedIn.Count; m++)
                                    {
                                        if (OsuBundles[k].Songs[l].CollectionsContainedIn[m] == OsuCollections[j].Name)
                                        {
                                            //Copy the file

                                            //If it is sorted
                                            if (DumpIndividualSubfolders.Checked)
                                            {
                                                if (!Directory.Exists(OutputPathBox.Text + "\\" + OsuCollections[j].Name)) Directory.CreateDirectory(OutputPathBox.Text + "\\" + OsuCollections[j].Name);
                                                try
                                                {
                                                    Log("Copying song " + OsuBundles[k].Songs[l].SongName + " to " + OsuCollections[j].Name + " directory.");
                                                    File.Copy(SongsPathBox.Text + "\\" + OsuBundles[k].Songs[l].SongPath,
                                                        OutputPathBox.Text + "\\" + OsuCollections[j].Name + "\\" + OsuBundles[k].Songs[l].SongName + " - " + OsuBundles[k].Songs[l].Artist + ".mp3");
                                                    copycount++;
                                                }
                                                catch
                                                {
                                                    Log("Unable to copy song " + OsuBundles[k].Songs[l].SongName + " to " + OsuCollections[j].Name + " directory.");
                                                    failcount++;
                                                }
                                            }
                                            //or it's not sorted
                                            else
                                            {
                                                try
                                                {
                                                    Log("Copying song " + OsuBundles[k].Songs[l].SongName + " to output directory.");
                                                    File.Copy(SongsPathBox.Text + "\\" + OsuBundles[k].Songs[l].SongPath,
                                                        OutputPathBox.Text + "\\" + OsuBundles[k].Songs[l].SongName + " - " + OsuBundles[k].Songs[l].Artist + ".mp3");
                                                    copycount++;
                                                }
                                                catch
                                                {
                                                    Log("Unable to copy song " + OsuBundles[k].Songs[l].SongName + " to output directory.");
                                                    failcount++;
                                                }
                                            }
                                            if (shouldStopExporting) { Log("Exporting process has been interrupted."); shouldStopExporting = false; return; };
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
            }
            Log("Finished exporting songs. " + copycount + " songs copied, " + failcount + " failed.");
            ThreadOff();
        }

        private void CachelessParse_Click(object sender, EventArgs e)
        {
            CachelessParse.Enabled = false;
            LoadCacheButton.Enabled = false;
            CachePathBox.Enabled = false;
            StopParseButton.Enabled = false;
            new Thread(Parse).Start();
            OpenDataButton_Click(null, null);
        }

        private void StopParseButton_Click(object sender, EventArgs e)
        {
            shouldStop = true;
            StopParseButton.Enabled = false;
            CachelessParse.Enabled = true;
        }

        private void SaveCacheButton_Click(object sender, EventArgs e)
        {
            string savepath = FormUtilities.SaveFile();
            if (savepath != "")
            {
                Log("Saving cache file");
                OsuSongParser.Save(OsuBundles, savepath);
                Log("Cache file saved");
            }
        }

        private void ExportSongsButton_Click(object sender, EventArgs e)
        {
            if (OutputPathBox.Text == "" || !Directory.Exists(OutputPathBox.Text))
            {
                MessageBox.Show("Error: Sorted output directory path not valid.", "ERROR");
                return;
            }
            StopExportButton.Enabled = true;
            ExportSongsButton.Enabled = false;
            new Thread(Export).Start();

        }

        private void StopExportButton_Click(object sender, EventArgs e)
        {
            shouldStopExporting = true;
            StopExportButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Extractor_Load(object sender, EventArgs e)
        {

        }
    }
}
