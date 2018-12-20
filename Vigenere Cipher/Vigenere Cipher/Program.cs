using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vigenere_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = Vigenere.operationChoice();
            string userword = Vigenere.userWord();
            string key = Vigenere.keyWord();
            Vigenere.runChoice(choice, userword, key);
        }
    }
}
