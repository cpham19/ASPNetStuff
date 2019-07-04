using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Keep popping the main menu until user selects exit option
            PrintMainMenu();
        }

        static void PrintMainMenu()
        {
            while (true)
            {
                List<Forum> forums = null;
                using (var db = new AppDbContext())
                {
                    forums = (from f in db.Forums
                              select f).ToList();
                }
                Console.WriteLine("Main Menu");
                foreach (var f in forums)
                {
                    Console.WriteLine(f.ToString());
                };

                Console.WriteLine("n) Create New Forum");
                Console.WriteLine("x) Exit");
                Console.Write("Please enter your choice: ");
                string input = Console.ReadLine();

                // Check if number input is a forum number that exists
                if (int.TryParse(input, out int n) == true)
                {
                    int number = int.Parse(input);

                    List<Forum> results = null;
                    using (var db = new AppDbContext())
                    {
                        results = (from f in db.Forums
                                  where f.Id == number
                                  select f).ToList();
                    }
                    if (results.Count == 0)
                    {
                        Console.WriteLine($"Forum #{number} doesn't exist! Please select a proper forum number!");
                    }
                    else
                    {
                        Console.WriteLine();
                        PrintForumMenu(results[0]);
                    }
                }
                // Create a new forum
                else if (input == "n")
                {
                    CreateNewForum();
                }
                // Exit the program
                else if (input == "x")
                {
                    break;
                }
                // Prompts the user for making a wrong choice
                else
                {
                    Console.WriteLine("Please enter a proper menu option!");
                }
                Console.WriteLine();
            }
        }

        static void PrintForumMenu(Forum forum)
        {
            while (true)
            {
                List<Topic> topics = null;
                using (var db = new AppDbContext())
                {
                    topics = (from t in db.Topics
                              where t.ForumID == forum.Id
                              select t).ToList();
                }
                Console.WriteLine($"Forum - {forum.ForumName}");
                foreach (var t in topics)
                {
                    Console.WriteLine(t.ToString());
                };

                Console.WriteLine("n) Create New Topic");
                Console.WriteLine("b) Back to Main Menu");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int b) == true)
                {
                    int number = int.Parse(input);

                    List<Topic> results = null;
                    using (var db = new AppDbContext())
                    {
                        results = (from t in db.Topics
                                   where t.Id == number && t.ForumID == forum.Id
                                   select t).ToList();
                    }

                    if (results.Count == 0)
                    {
                        Console.WriteLine("That topic doesn't exist! Please select a proper topic number!");
                    }
                    else
                    {
                        Console.WriteLine();
                        PrintTopicMenu(results[0]);
                    }
                }
                // Create a new topic
                else if (input == "n")
                {
                    Console.WriteLine();
                    CreateNewTopic(forum);
                }
                // Go back to main menu
                else if (input == "b")
                {
                    break;
                }
                // Prompts the user for making a wrong choice
                else
                {
                    Console.WriteLine("Please enter a proper menu option!");
                }
                Console.WriteLine();
            }
        }

        static void PrintTopicMenu(Topic topic)
        {
            while (true)
            {
                Console.WriteLine($"Topic - {topic.TopicName} (Posted on {topic.TopicDate})");
                Console.WriteLine($"{topic.TopicContent}");
                List<Reply> replies = null;
                using (var db = new AppDbContext())
                {
                    replies = (from r in db.Replies
                              where r.TopicId == topic.Id
                              select r).ToList();
                }
                foreach (var r in replies)
                {
                    Console.WriteLine(r.ToString());
                };

                Console.WriteLine("n) Create New Reply");
                Console.WriteLine("b) Back to Forum Menu");
                string input = Console.ReadLine();

                // Create a new reply
                if (input == "n")
                {
                    Console.WriteLine();
                    CreateNewReply(topic);
                }
                // Go back to forum menu
                else if (input == "b")
                {
                    break;
                }
                // Prompts the user for making a wrong choice
                else
                {
                    Console.WriteLine("Please enter a proper menu option!");
                }
                Console.WriteLine();
            }
        }

        static void CreateNewForum()
        {
            Console.Write("Please enter the forum name: ");
            string name = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var f = new Forum
                {
                    ForumName = name
                };
                db.Forums.Add(f);
                db.SaveChanges();
            }
        }

        static void CreateNewTopic(Forum forum)
        {
            Console.Write("Please enter the topic name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the topic content: ");
            string content = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var t = new Topic
                {
                    TopicName = name,
                    TopicContent = content,
                    TopicDate = DateTime.Now,
                    ForumID = forum.Id
                };
                db.Topics.Add(t);
                db.SaveChanges();
            }
        }

        static void CreateNewReply(Topic topic)
        {
            Console.Write("Please enter the reply: ");
            string content = Console.ReadLine();

            using (var db = new AppDbContext())
            {
                var r = new Reply
                {
                    ReplyContent = content,
                    ReplyDate = DateTime.Now,
                    TopicId = topic.Id
                };
                db.Replies.Add(r);
                db.SaveChanges();
            }
        }
    }
}
