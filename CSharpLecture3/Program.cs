using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace CSharpLecture3
{

    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
    }

    // Custom Exception
    public class InvalidStudentNameException : Exception
    {
        public InvalidStudentNameException()
        {

        }

        public InvalidStudentNameException(string name)
            : base(String.Format("Invalid Student Name: {0}", name))
        {

        }

    }

    // Generic Class
    public class GenericList<T>
    {
        public void Add(T input)
        {

        }
    }

    class Program
    {
        public Dictionary<string, List<string>> Dictionary { get; set; }

        public Program(String file)
        {
            Dictionary = new Dictionary<string, List<string>>();

            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                if (line.StartsWith("#")) continue;
                string[] words = line.Split(new char[] { '\t' });
                List<string> translations;
                if (Dictionary.TryGetValue(words[0], out translations))
                {
                    translations.Add(words[1]);
                }
                else
                {
                    translations = new List<string>();
                    translations.Add(words[1]);
                    Dictionary.Add(words[0], translations);
                }
            }
        }

        public List<string> Translate(string word)
        {
            List<string> definitions;
            Dictionary.TryGetValue(word, out definitions);
            return definitions;
        }

        static void Main(string[] args)
        {
            // Exception Handling
            try
            {
                FutureFeature();
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("DONE!");
            }

            Student newStudent = null;
            try
            {
                newStudent = new Student();
                newStudent.StudentName = "James007";

                ValidateStudent(newStudent);
            }
            catch (InvalidStudentNameException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Student newStudent2 = null;
            try
            {
                newStudent2 = new Student();
                newStudent2.StudentName = "James";

                ValidateStudent(newStudent2);
            }
            catch (InvalidStudentNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(newStudent2.StudentName);
            }

            var list = new GenericList<int>();
            list.Add(10);
            list.Add(20);

            List<int> intList = new List<int>();
            intList.Add(10);
            intList.Add(20);
            foreach (var el in intList)
            {
                Console.WriteLine(el);
            }


            string[] lines = File.ReadAllLines("Test.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

        public static void StartTranslate()
        {
            Console.Write("Please enter the path to the dictionary file: ");
            Program translator = new Program(Console.ReadLine());

            while (true)
            {
                Console.Write("Please enter a word to translate or \"x\" to exit: ");
                string word = Console.ReadLine();
                if (word.ToLower() == "x") break;

                var translations = translator.Translate(word);
                Console.WriteLine("English: {0}", word);
                Console.WriteLine("Spanish:");
                if (translations != null)
                    for (int i = 0; i < translations.Count; ++i)
                        Console.WriteLine("\t{0}. {1}", i + 1, translations[i]);
                else
                    Console.WriteLine("\tNo translation found");
            }
        }

        public static void FutureFeature()
        {
            throw new NotImplementedException();
        }


        private static void ValidateStudent(Student std)
        {
            Regex regex = new Regex("^[a-zA-Z]+$");

            if (!regex.IsMatch(std.StudentName))
                throw new InvalidStudentNameException(std.StudentName);

        }
    }
}
