namespace woertli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _path = "src\\words.txt";
            var _manager = new Manager(_path);
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
            while (anotherRound)
            {
                foreach (string key in _dictionary.Keys)
                {
                    Console.Clear();
                    Console.WriteLine(key);
                    Console.ReadLine(); // should read the correct solution
                }
            }
        }
    }
}
