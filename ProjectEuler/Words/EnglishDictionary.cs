using System.Collections.Generic;
using System.IO;

namespace ProjectEuler.Words
{
    public static class EnglishDictionary
    {
        private static readonly HashSet<string> _words = new HashSet<string>();
        private static bool _isInitialized = false;
        private static void InitializeDictionary()
        {
            StreamReader reader = new StreamReader(@"~\..\..\..\Words\words.txt");
            while (!reader.EndOfStream)
            {
                _words.Add(reader.ReadLine());
            }
            reader.Close();
            _isInitialized = true;
        }
        public static bool IsWord(string word)
        {
            if (!_isInitialized)
            {
                InitializeDictionary();
            }
            return _words.Contains(word);
        }
    }
}
