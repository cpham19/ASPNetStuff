using System;

namespace Lab4
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"[{Id}, {Name} {Age}]";
        }
    }
}
