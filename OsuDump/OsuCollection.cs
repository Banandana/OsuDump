using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDump
{
    class OsuCollection
    {
        public OsuCollection(String _name)
        {
            CollectionName = _name;
            Hashes = new List<string>();
        }

        string CollectionName;

        public List<string> Hashes
        {
            get;
            set;
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
