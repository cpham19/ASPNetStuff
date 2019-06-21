using System;
using System.Collections.Generic;
using ExtensionMethods;

namespace CSharpLecture4
{

    // Indexer syntax
    class SampleCollection<T>
    {
        // Declare an array to store the data elements.
        private T[] arr = new T[100];

        // Define the indexer to allow client code to use [] notation.
        public T this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
    }

    static class Program
    {
        // Extension Method
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // C# Delegate
        public delegate int BinaryOp(int op1, int op2);

        static int Add(int a, int b) => a + b;

        static int Add2(int x, int y) => x + y;

        // Closure
        public static Func<int, int> GetAFunc()
        {
            var myVar = 1;
            Func<int, int> inc = delegate (int var1)
            {
                myVar = myVar + 1;
                return var1 + myVar;
            };
            return inc;
        }

        static void Main(string[] args)
        {
            // Accessing elements by index
            List<int> list = new List<int>();
            list.Add(10);
            list.Add(20);
            list.Add(30);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, list[i]);
            }

            // Indexer syntax
            var stringCollection = new SampleCollection<string>();
            stringCollection[0] = "Hello, World";
            Console.WriteLine(stringCollection[0]);

            // Extension Method
            string s = "Hello THERE";
            Console.WriteLine(s.WordCount());

            // Delegate object that references the method
            BinaryOp bop = new BinaryOp(Program.Add);
            Console.WriteLine(bop(10, 20));

            // Multicasting: references multiple methods and invoke them together using += operator which adds a method to the list of methods referenced by delegate
            bop += Program.Add2;

            Console.WriteLine(bop(10, 40));

            // Anonymous Method
            int c = 100;
            BinaryOp bop2 = delegate (int a, int b) { return a + b + c; };
            Console.WriteLine(bop2(10, 20));

            // Lambda Expression is easiest and best way to write anonymous method
            BinaryOp bop3 = (int a, int b) => { return a + b + c; };

            // Closure example
            var inc = GetAFunc();
            Console.WriteLine(inc(5));
            Console.WriteLine(inc(6));
        } 
    }
}
