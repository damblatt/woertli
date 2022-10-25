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
        public string FirstLanguage { get; set; }
        public string SecondLanguage { get; set; }

        Dictionary<string, string> _dictionary = new Dictionary<string, string>();

        public Manager(string location)
        {
            Location = location;
            SetLanguages();
        }

        public int GetNumber()
        {
            string? input;
            int n;
            bool criteria;
            Console.WriteLine("[1] Next word");
            Console.WriteLine("[2] I was correct!");
            while (criteria = (!Int32.TryParse(input = Console.ReadLine(), out n) || n < 0 | n > 2))
            {
                Console.WriteLine("[1] Next word");
                Console.WriteLine("[2] I was correct!");
            }
            return n;
        }
        private void SetLanguages()
        {
            string firstLine = File.ReadLines(Location).First();
            string[] languages = firstLine.Split('|');
            FirstLanguage = languages[0];
            SecondLanguage = languages[1];
        }

        public int SelectLanguage()
        {
            string? input;
            int n;
            bool criteria;
            Console.WriteLine("Please enter the number of the language you want to start with:");
            Console.WriteLine($"1) {FirstLanguage}");
            Console.WriteLine($"2) {SecondLanguage}");
            while (criteria = (!Int32.TryParse(input = Console.ReadLine(), out n) | n < 0 | n > 2))
            {
                Console.WriteLine("Please enter the number of the language you want to start with:");
                Console.WriteLine($"1) {FirstLanguage}");
                Console.WriteLine($"2) {SecondLanguage}");
            }
            return n;
        }

        public Dictionary<string, string> GetDictionary(int selectedLanguage)
        {
            string[] wordPairs = File.ReadAllText(Location).Split(new string[] {"|", Environment.NewLine}, StringSplitOptions.None);

            switch (selectedLanguage)
            {
                case 1:
                    for (int i = 0; i < wordPairs.Length; i = i + 2)
                    {
                        if (!(_dictionary.ContainsKey(wordPairs[i])))
                        {
                            _dictionary.Add(wordPairs[i], wordPairs[i + 1]);
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder(_dictionary[wordPairs[i]]);
                            sb.Append(", " + wordPairs[i + 1]);
                        }
                    }
                    _dictionary.Remove(FirstLanguage);
                    break;

                case 2:
                    for (int i = 0; i < wordPairs.Length; i = i + 2)
                    {
                        if (!(_dictionary.ContainsKey(wordPairs[i +1])))
                        {
                            _dictionary.Add(wordPairs[i +1], wordPairs[i]);
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder(_dictionary[wordPairs[i +1]]);
                            sb.Append(", " + wordPairs[i]);
                        }
                    }
                    _dictionary.Remove(SecondLanguage);
                    break;

                default: break;
            }

            return _dictionary;
        }

        public Dictionary<string, string> ShuffleDictionary(Dictionary<string, string> dictionary)
        {
            Random rand = new Random();
            dictionary = dictionary.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);
            return dictionary;
        }

        public bool TrueOrFalse(string answer, string value)
        {
            string answerWithoutSpaces = answer.Replace(" ", "").ToLower();
            string valueWithoutSpaces = value.Replace(" ", "").ToLower();

            return answerWithoutSpaces == valueWithoutSpaces;
        }
    }
}
