using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Find data in array
            var names = new List<string>();
            names.Add("Calvin");
            names.Add("Paul");
            names.Add("Daniel");
            names.Add("Jaime");
            names.Add("Carlos");
            names.Add("Leonard");

            var results = new List<string>();
            foreach(var name in names)
            {
                if (name.StartsWith("J"))
                {
                    results.Add(name);
                }
            }
            results.Sort();

            foreach(var result in results)
            {
                Console.WriteLine(result);
            }

            // Using LINQ
            var results1 = from name in names
                           where name.StartsWith("C")
                           orderby name
                           select name;

            foreach (var result in results1)
            {
                Console.WriteLine(result);
            }

            // Alternative
            var results2 = names.Where(name => name.StartsWith("P")).OrderBy(name => name).Select(name => name);
            foreach (var result in results2)
            {
                Console.WriteLine(result);
            }

        
        }
    }
}
