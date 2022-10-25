using System.Runtime.InteropServices;

namespace woertli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _path = "src\\words.txt";
            var _manager = new Manager(_path);
            var _wrongDictionary = new Dictionary<string, string>();
            var _tempDictionary = new Dictionary<string, string>();
            var _dictionary = new Dictionary<string, string>();

            if (new FileInfo(_path).Length == 0)
            {
                Console.WriteLine($"Please copy your wordlist into the file '{_path}'. Your word file must be written in the same syntax as the example.");
            } else
            {
                int language = _manager.SelectLanguage();
                // creates dictionary
                _dictionary = _manager.GetDictionary(language);
                // shuffle dictionary
                _dictionary = _manager.ShuffleDictionary(_dictionary);
            }

            bool anotherRound = true;
            _tempDictionary = _dictionary;
            while (anotherRound)
            {
                foreach (KeyValuePair<string, string> kvp in _tempDictionary)
                {
                    Console.Clear();
                    Console.WriteLine("write the correct translation:");
                    Console.WriteLine(kvp.Key);
                    string answer = Console.ReadLine();
                    if (_manager.TrueOrFalse(answer, kvp.Value) == false)
                    {
                        Console.WriteLine($"wrong. you wrote '{answer}', but the correct answer would've been '{kvp.Value}'.");
                        int i = _manager.GetNumber();
                        if (i == 1)
                        {
                            _wrongDictionary.Add(kvp.Key, kvp.Value);
                        }
                    }
                    Thread.Sleep(700);
                }

                Console.Clear();
                Console.WriteLine("you finished the current run. here are the words you didn't know:");
                foreach (KeyValuePair<string, string> kvp in _wrongDictionary)
                {
                    Console.WriteLine($"{kvp.Key} = {kvp.Value}");
                }
                if (_wrongDictionary.Count > 0)
                {
                    float wrongAnswers = _wrongDictionary.Count;
                    float totalWords = _tempDictionary.Count;
                    float percent = 100 - (wrongAnswers / totalWords * 100);
                    Console.WriteLine($"\nin total you answered {percent}% correct.");
                    Console.WriteLine("\npress any key to start the next round. press backspace to exit.");
                    var ben = Console.ReadKey();
                    if (ben.Key == ConsoleKey.Backspace)
                    {
                        Console.WriteLine("exit...");
                        anotherRound = false;
                    }
                }
                _tempDictionary.Clear();
                foreach (KeyValuePair<string, string> kvp in _wrongDictionary)
                {
                    _tempDictionary.Add(kvp.Key, kvp.Value);
                }
                _wrongDictionary.Clear();
            }
        }
    }
}
