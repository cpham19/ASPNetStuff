using System;

namespace CSharpLecture1
{
    class Foo
    {
        public int value = 10;
    }

    class Person
    {
        public Address address;
    }

    class Address
    {
        public string street;
        public string city;
        public string state;
        public string zip;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Implicit Typing with Var (Useful for dynamic created classes)
            //var a = 10; // int
            //var b = 20.1; // double
            //var c = true; // bool

            // Value vs. Reference
            int a = 10;
            int b = a;
            b = 20;
            Console.WriteLine(a);

            Foo f1 = new Foo();
            Foo f2 = f1;
            f2.value = 20;
            Console.WriteLine(f1.value);

            Foo f3 = new Foo();
            change(f3);
            Console.WriteLine(f3.value);

            // Interpolated String with $
            string name = "john";
            string greeting = $"Hello, {name}!";
            Console.WriteLine(greeting);

            // Verbatim identifier
            string path = @"C\test\files";

            // Constants
            const double pi = 3.1415;

            // String equality
            string s1 = "abc";
            string s2 = "ABC";
            Console.WriteLine(s1 == s2);
            Console.WriteLine(s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase));

            // Null Coalescing Operator ??  x != null ? x : y
            int? x = null;
            int y = 10;
            Console.WriteLine(x != null ? x : y);
            Console.WriteLine(x ?? y);

            // Null Conditional Operator ? (accessing object member or array element)
            Console.WriteLine(f1?.value); // f1 == null ? null : f1.value;

            // Null Conditional Example
            Person p1 = new Person();
            p1.address = new Address();
            p1.address.city = "Los Angeles";
            Console.WriteLine(CheckIfLivesInLA(p1));

            // Statements
            string[] colors = { "Red", "Blue", "Orange" };
            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }

            // Basic IO
            Console.Write("Write your name: ");
            string nameInput = Console.ReadLine();
            Console.Write("Write integer: ");
            int intInput = int.Parse(Console.ReadLine());
            Console.Write("Write double: ");
            double doubleInput = double.Parse(Console.ReadLine());

            Console.WriteLine($"Your inputs are {nameInput}, {intInput}, and {doubleInput:c}");
        }

        // Pass by reference
        static void change(int a)
        {
            a = 20;
        }

        static void change (Foo a)
        {
            a.value = 20;
        }

        static bool CheckIfLivesInLA(Person p)
        {
            if (p == null)
            {
                return false;
            }
            else
            {
                if (p.address == null)
                {
                    return false;
                }
                else {
                    return p.address.city == "Los Angeles";
                }
            }
        }
    }
}
