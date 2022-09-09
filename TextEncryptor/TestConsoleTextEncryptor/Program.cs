using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestConsoleTextEncryptor
{
    internal class Program
    {
        private static byte[] IV = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to Itai's text Encryptor");
            Console.Write("Select mode: \n0- Encryptor\n1- Decryptor\n... ");
            string text;
            while (true)
            {
                text = Console.ReadLine();
                if (text != "0" && text != "1")
                {
                    PrintWithColor("try again :(\n", ConsoleColor.Red);
                    Console.Write("... ");
                    continue;
                }
                break;
            }
            if (text == "0")
            {
                Encrypt();
            }
            else if (text == "1")
            {
                Decrypt();
            }
        }

        static void Encrypt()
        {
            Console.Write("welcom to the Encryptor!\nplease enter your file location to encrypt\n... ");
            string filePath;
            while (true)
            {
                filePath = Console.ReadLine();
                if (!File.Exists(filePath))
                {
                    PrintWithColor("file not found! try again :(\n", ConsoleColor.Red);
                    Console.Write("... ");
                    continue;
                }
                PrintWithColor("file found!", ConsoleColor.Green);
                Console.WriteLine(" at '{0}'",filePath);
                break;
            }
            List<string> lines = File.ReadAllLines(filePath).ToList();

            Console.Write("please enter your encryption key\n... ");
            string key;
            while (true)
            {
                key = Console.ReadLine();
                if (key.Length!=16)
                {
                    PrintWithColor("your key needs to be 16 chars long! try again :(\n", ConsoleColor.Red);
                    Console.Write("... ");
                    continue;
                }
                PrintWithColor("key set!", ConsoleColor.Green);
                break;
            }
            Console.WriteLine();
            List<string> newLines = new List<string>();
            foreach (string line in lines)
            {
                newLines.Add(Encryptor.Encrypt(line, key, IV));
            }
            string ecryptedText = string.Join("\n", newLines.ToArray());
            Console.WriteLine("Encrypted text:\n"+ecryptedText);

            Console.Write("are you sure you what to save the changes?\ntype y/n... ");
            string confirm;
            while (true)
            {
                confirm = Console.ReadLine();
                if (confirm == "yes" || confirm == "y" || confirm == "no" || confirm == "n")
                {
                    break;
                }
                PrintWithColor("invalid input! try again :(\n", ConsoleColor.Red);
                Console.Write("... ");
            }
            if (confirm == "yes" || confirm == "y")
            {
                File.WriteAllLines(filePath, newLines);
            }
        }

        static void Decrypt()
        {
            Console.Write("welcom to the Decryptor!\nplease enter your file location to decrypt\n... ");
            string filePath;
            while (true)
            {
                filePath = Console.ReadLine();
                if (!File.Exists(filePath))
                {
                    PrintWithColor("file not found! try again :(\n", ConsoleColor.Red);
                    Console.Write("... ");
                    continue;
                }
                PrintWithColor("file found!", ConsoleColor.Green);
                Console.WriteLine(" at '{0}'", filePath);
                break;
            }
            List<string> lines = File.ReadAllLines(filePath).ToList();

            Console.Write("please enter your Decryption key\n... ");
            string key;
            while (true)
            {
                key = Console.ReadLine();
                if (key.Length != 16)
                {
                    PrintWithColor("your key needs to be 16 chars long! try again :(\n", ConsoleColor.Red);
                    Console.Write("... ");
                    continue;
                }
                PrintWithColor("key set!", ConsoleColor.Green);
                break;
            }
            Console.WriteLine();
            List<string> newLines = new List<string>();
            foreach (string line in lines)
            {
                newLines.Add(Encryptor.Decrypt(line, key, IV));
            }
            string ecryptedText = string.Join("\n", newLines.ToArray());
            Console.WriteLine("Encrypted text:\n" + ecryptedText);

            Console.Write("are you sure you what to save the changes?\ntype y/n... ");
            string confirm;
            while (true)
            {
                confirm = Console.ReadLine();
                if (confirm == "yes" || confirm == "y" || confirm == "no" || confirm == "n")
                {
                    break;
                }
                PrintWithColor("invalid input! try again :(\n", ConsoleColor.Red);
                Console.Write("... ");
            }
            if (confirm == "yes" || confirm == "y")
            {
                File.WriteAllLines(filePath, newLines);
            }
        }

        static void PrintWithColor(string text ,ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = defaultColor;
        }
    }
}
