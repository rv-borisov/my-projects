using System;

namespace VernamCipher
{
    class Program
    {
        static Random rng = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter text to encrypt : ");
            string enteredtext = Console.ReadLine(); 
            int len = enteredtext.Length; 
            char[] sourcetext = new char[len]; 
            char[] key = new char[len];
            char[] encryptedtext = new char[len];
            char[] decryptedtext = new char[len];
            sourcetext = enteredtext.ToCharArray();
            key = GetKey(key);

            encryptedtext = Encryption(sourcetext, key);

            Console.WriteLine(" Entered text : " + enteredtext);
            foreach (int i in enteredtext)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write(" Key : ");
            Console.WriteLine(key);
            foreach (int i in key)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("(this is Unicode text)");

            Console.Write(" Encrypted text : ");
            Console.WriteLine(encryptedtext);
            foreach (int i in encryptedtext)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("(this is Unicode text)");

            decryptedtext = Decryption(encryptedtext, key);

            Console.Write(" Decrypted text : ");
            Console.WriteLine(decryptedtext);
            foreach (int i in decryptedtext)
            {
                Console.Write(i);
                Console.Write(" ");
            }
            Console.WriteLine("(this is Unicode text)");
        }
        static char[] GetKey(char[] key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = Convert.ToChar(rng.Next(48,122));
            }
            return key;
        }
        static char[] Encryption(char[] sourcetext, char[] key)
        {
            char[] encryptedtext = new char[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                encryptedtext[i] = Convert.ToChar(sourcetext[i] ^ key[i]);
            }
            return encryptedtext;
        }
        static char[] Decryption(char[] encryptedtext, char[] key)
        {
            char[] sourcetext = new char[key.Length];
            for (int i = 0; i < key.Length; i++)
            {
                sourcetext[i] = Convert.ToChar(encryptedtext[i] ^ key[i]);
            }
            return sourcetext;
        }

    }
}
