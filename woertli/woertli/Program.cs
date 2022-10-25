namespace woertli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string _path = "src\\words.txt";
            var _manager = new Manager(_path);
            var _dictionary = new Dictionary<string, string>();

            Console.WriteLine("Wörtli");
            if (new FileInfo(_path).Length == 0)
            {
                Console.WriteLine($"Please copy your wordlist into the file '{_path}'. Your word file must be written in the same syntax as the example.");
            } else
            {
                _dictionary = _manager.GetDictionary();
            }
        }
    }
}
