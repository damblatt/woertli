using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace woertli
{
    public class Manager
    {
        public string Location { get; set; }

        Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public Manager(string location)
        {
            Location = location;
        }

        public Dictionary<string, string> GetDictionary()
        {
            string[] wordPairs = File.ReadAllText(Location).Split(new string[] {"|", Environment.NewLine}, StringSplitOptions.None);
            for(int i = 0; i < wordPairs.Length; i = i +2)
            {
                if (!(_dictionary.ContainsKey(wordPairs[i])))
                {
                    _dictionary.Add(wordPairs[i], wordPairs[i +1]);
                }
                else
                {
                    StringBuilder sb = new StringBuilder(_dictionary[wordPairs[i]]);
                    sb.Append(", " + wordPairs[i +1]);
                }
            }
            
            return _dictionary;
        } 
    }
}
