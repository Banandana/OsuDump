using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OsuDump
{
    class OsuCollectionReader
    {
        public static List<OsuCollection> GetCollections(String FileName)
        {
            try
            {

                List<OsuCollection> CollectionsList = new List<OsuCollection>();

                BinaryReader Reader = new BinaryReader(File.OpenRead(FileName));

                Reader.ReadBytes(4);
                //First 4 bytes are an unknown integer

                int CollectionCount = Reader.ReadInt32();
                //Second 4 bytes aren't in Osu's shitty format, number of 'Collections'

                for (int i = 0; i < CollectionCount; i++)
                {
                    Reader.ReadByte();
                    string key = ProcessString(Reader);

                    OsuCollection CurrentCollection = new OsuCollection(key);

                    int NumberofSongs = Reader.ReadInt32();

                    for (int j = 0; j < NumberofSongs; j++)
                    {
                        Reader.ReadByte();//Some bullshit
                        string hash = ProcessString(Reader);//The actual string
                        CurrentCollection.AddHash(hash);
                    }

                    CollectionsList.Add(CurrentCollection);
                }

                Reader.Close();
                return CollectionsList;
            }
            catch
            {
                Console.WriteLine("Unable to read Osu collections database.");
                return new List<OsuCollection>();
            }
        }

        static string ProcessString(BinaryReader Reader)
        {
            byte length = Reader.ReadByte();
            if (length == 0) return null;
            return System.Text.Encoding.UTF8.GetString(Reader.ReadBytes(length));
        }
    }
}
