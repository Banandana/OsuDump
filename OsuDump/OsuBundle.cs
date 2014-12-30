using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsuDump
{
    public class OsuBundle
    {
        public string SongName;
        public List<OsuSong> Songs;
        public OsuBundle()
        {
            Songs = new List<OsuSong>();
        }
    }
}
