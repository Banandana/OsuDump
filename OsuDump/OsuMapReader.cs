using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OsuDump
{
    class OsuMapReader
    {
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

        public static string GetMP3NameFromMap(string FileName)
        {
            return GetValueFromMap(FileName, "AudioFilename");
        }

        public static string GetHashFromMap(string FileName)
        {
            try
            {
                MD5 HashCode = MD5.Create();

                return BitConverter.ToString(HashCode.ComputeHash(File.OpenRead(FileName)));
            }
            catch
            {
                //Unable to create MD5 from file
                return "";
            }
        }
    }
}
