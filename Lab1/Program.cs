using System;
using System.Linq;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the length of the password: ");
            int length = int.Parse(Console.ReadLine());

            char[] array = "abcdefghijklmnopqrstuvwxyzABCDEGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

            string s = "";

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                s += array[random.Next(array.Length)];
            }

            Console.WriteLine("Generated Random Password: " + s);

            Console.WriteLine();

            Console.Write("Please enter three words: ");
            string[] words = Console.ReadLine().Split(" ");
            Array.Sort(words);

            Console.Write("Sorted: ");
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
        }
    }
}
