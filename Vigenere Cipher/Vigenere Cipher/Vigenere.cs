using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigenere_Cipher
{
    class Vigenere
    { 
        private static string operation;

        public static char[] alphabet = new char[26]
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
        };

        public static string operationChoice()
        {
            string choice = "null";
            while (choice == "null")
            {
                Console.WriteLine("!!!!NOTICE!!!!\nCurrent implementation doesn't handle spaces or special characters. \nPlease entry your word, phrase and key in all lowercase characters\nand without spaces.\n\n  Would you like to: \n (1) Encode a word or phrase \n (2) Decode a word or phrase");
                Console.Write("  ->  ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    operation = "encode";
                }
                else if (choice == "2")
                {
                    operation = "decode";
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    choice = "null";
                }
            }
                return operation;
        }

        public static string userWord()
        {
            Console.Write("Please input a word or phase to {0}: ->  ", operation);
            string wordChoice = Console.ReadLine();
            return wordChoice;
        }

        public static string keyWord()
        {
            Console.Write("Please enter a key for your Cypher: ->  ");
            string keyChoice = Console.ReadLine();
            return keyChoice;
        }

        public static string decode(string toDecode, string key)
        {
            string decoded;
            List<char> results = new List<char>();
            int keyPosition = 0;
            foreach (char i in toDecode)
            {
                char keyChar = key[keyPosition];
                int decodePosition = countDistance(keyChar, i);
                results.Add(alphabet[decodePosition]);
                keyPosition++;
                if (keyPosition >= key.Length)
                {
                    keyPosition = 0;
                }
            }
            decoded = string.Concat(results);
            return decoded;
        }

        public static int countDistance(char start, char end)
        {
            int count = 0;
            int position = Array.IndexOf(alphabet, start);
            while (alphabet[position] != end)
            {
                count++;
                position++;
                if (position >= alphabet.Length)
                {
                    position = 0;
                }
            }
            //Console.WriteLine(count);   // Print debugging
            return count;
        }

        public static int countDistanceEncode(char start, char end)
        {
            int count = 0;
            int position = 0;
            while (alphabet[position] != end)
            {
                count++;
                position++;
                if (position >= alphabet.Length)
                {
                    position = 0;
                }
            }
            //Console.WriteLine(count);   // Print debugging
            return count;
        }

        public static string encode(string toEncode, string key)
        {
            string coded;
            List<char> results = new List<char>();
            int keyPosition = 0;
            foreach (char i in toEncode)
            {
                char keyChar = key[keyPosition];
                int encodePosition = countDistanceEncode(alphabet[0], keyChar);
                int charEncode = Array.IndexOf(alphabet, i);
                int move = charEncode + encodePosition;
                if (move >= alphabet.Length - 1)
                {
                    move = move - alphabet.Length;
                }
                results.Add(alphabet[move]);
                keyPosition++;
                if (keyPosition >= key.Length)
                {
                    keyPosition = 0;
                }
            }
            coded = string.Concat(results);
            return coded;
        }

        static public void runChoice(string choice, string userword, string key)
        {
            if (choice == "encode")
            {
                string encoded = encode(userword, key);
                Console.WriteLine("Your encoded string is: {0}", encoded);
            }
            else if (choice == "decode")
            {
                string decoded = decode(userword, key);
                Console.WriteLine("Your string decodes to: {0}", decoded);
            }
        }
    }

}
