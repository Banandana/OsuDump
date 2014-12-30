using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDump
{
    class OsuCollection
    {
        string CollectionName;
        List<string> Hashes;

        public OsuCollection(String Name)
        {
            CollectionName = Name;
            Hashes = new List<string>();
        }

        public string Name
        {
            get { return CollectionName; }
            set { CollectionName = value; }
        }

        public void AddHash(string Hash)
        {
            if (Hash != null)
            {
                Hashes.Add(Hash);
            }
        }

        public void RemoveHash(string Hash)
        {
            if (Hash != null)
            {
                Hashes.Remove(Hash);
            }
        }

        public string GetHashByIndex(int Index)
        {
            if (Index > Hashes.Count - 1 || Index < 0) return "";
            return Hashes[Index];
        }

        public int GetHashCount()
        {
            return Hashes.Count;
        }
    }
}
