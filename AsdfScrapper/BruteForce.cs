using System.Collections.Generic;
using System.Linq;

namespace WebRequestTest
{
    class BruteForce
    {
        private readonly char[] CharactersToTest;
        private readonly List<string> BruteForceUsernames;
        private long ComputedKeys;

        public BruteForce()
        {
            CharactersToTest = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E',
                'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R',
                'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5',
                '6', '7', '8', '9', '0'
            };
            BruteForceUsernames = new List<string>();
        }

        public List<string> GetUsernames()
        {
            return BruteForceUsernames;
        }

        public void Start(int keyLength)
        {
            ComputedKeys = 0;
            var keyChars = CreateCharArray(keyLength, CharactersToTest[0]);
            var indexOfLastChar = keyLength - 1;
            CreateNewKey(0, keyChars, keyLength, indexOfLastChar);
        }

        private char[] CreateCharArray(int length, char defaultChar)
        {
            return (from c in new char[length] select defaultChar).ToArray();
        }

        private void CreateNewKey(int currentCharPosition, char[] keyChars, int keyLength, int indexOfLastChar)
        {
            var nextCharPosition = currentCharPosition + 1;

            for (int i = 0; i < CharactersToTest.Length; i++)
            {
                keyChars[currentCharPosition] = CharactersToTest[i];

                if (currentCharPosition < indexOfLastChar)
                {
                    CreateNewKey(nextCharPosition, keyChars, keyLength, indexOfLastChar);
                }
                else
                {
                    ComputedKeys++;
                    BruteForceUsernames.Add(new string(keyChars));
                }
            }
        }
    
    }
}
