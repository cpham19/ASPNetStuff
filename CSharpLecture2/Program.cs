using System;

namespace CSharpLecture2
{
    class Circle
    {
        private static int idSeed = 1;
        public int Id { get; }
        public double Radius { get; set; }

        public string Color
        {
            // Full property syntax
            get { return Color; }
            set { Color = value; }
        }

        public Circle(double radius)
        {
            Id = idSeed++;
            Radius = radius;
            Color = "Blue";
        }

    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }

        public Person(string name)
        {
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(2.5);
            Console.WriteLine(c1.Id);
            Console.WriteLine(c1.Radius);
            c1.Radius = 3.5;
            Console.WriteLine(c1.Radius);

            Console.WriteLine(Add2(2, 3));

            // Optional Arguments
            Console.WriteLine(Add3(20));

            // Named Arguments
            Console.WriteLine(Add3(x: 20, y: 50));

            // Ref modifier
            Change(ref c1);
            Console.WriteLine(c1.Radius);

            // Out modifier
            int a;
            string b;
            string c;
            Assign(out a, out b, out c);
            Console.WriteLine($"{a} {b} {c == null}");

            // Params modifier
            UseParams(1, 2, 3, 4);
            UseParams2(1, "HELLO", "THERE");

            int[] myIntArray = { 5, 6, 7, 8, 9 };
            UseParams(myIntArray);

            object[] myObjArray = { 2, 'b', "test", "again" };
            UseParams2(myObjArray);

            // Object Instantiation and Initialization
            Person p1 = new Person();
            p1.Name = "John";
            p1.Age = 25;

            Person p2 = new Person("John");
            p2.Age = 25;

            Person p3 = new Person {Name = "John", Age = 25};

            Person p4 = new Person("John") {Age = 25};
        }

        // Regular method
        public int Add(int x, int y)
        {
            return x + y;
        }

        // Simplified Method
        public static int Add2(int x, int y) => x + y;

        // Optional Arguments
        public static int Add3(int x, int y = 20) => x + y;

        // Pass by reference
        public static void Change(ref Circle c)
        {
            c = new Circle(5.5);
        }

        public static void Assign(out int a, out string b, out string c)
        {
            a = 25;
            b = "HELLO";
            c = null;
        }

        public static void UseParams(params int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }

        public static void UseParams2(params object[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
