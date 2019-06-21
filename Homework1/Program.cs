using System;
using System.Collections.Generic;

namespace Homework1
{
    public class Forum
    {
        private static int idSeed = 1;
        private int topicIdSeed = 1;
        public int ForumID { get;}
        public string ForumName { get; set; }
        public List<Topic> topics;

        public Forum(string name)
        {
            ForumID = idSeed++;
            ForumName = name;
            topics = new List<Topic>();
        }

        public void AddTopic(string name, string content)
        {
            topics.Add(new Topic(topicIdSeed++, name, content));
        }
    }

    public class Topic
    {
        public int TopicID { get;}
        public string TopicName { get; set; }
        public string TopicDate { get; set; }

        public string TopicContent { get; set; }

        private int ReplyIdSeed = 1;
        public List<Reply> replies;

        public Topic(int id, string name, string content)
        {
            TopicID = id;
            TopicName = name;
            DateTime date = DateTime.Now;
            TopicDate = date.ToString("MM/dd/yyyy hh:mm tt");
            TopicContent = content;
            replies = new List<Reply>();
        }

        public void AddReply(string content)
        {
            replies.Add(new Reply(ReplyIdSeed++,content));
        }
    }

    public class Reply
    {
        public int ReplyID { get; }
        public string ReplyContent { get; set; }
        public string ReplyDate { get; set; }

        public Reply(int id, string content)
        {
            ReplyID = id;
            ReplyContent = content;
            DateTime date = DateTime.Now;
            ReplyDate = date.ToString("MM/dd/yyyy hh:mm tt");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Forum> forums = new List<Forum>();

            // Keep popping the main menu until user selects exit option
            PrintMainMenu(forums);
        }

        static void PrintMainMenu(List<Forum> forums)
        {
            while (true)
            {
                Console.WriteLine("Main Menu");

                if (forums.Count != 0)
                {
                    for (int i = 0; i < forums.Count; i++)
                    {
                        Console.WriteLine($"{forums[i].ForumID}) Forum - {forums[i].ForumName}");
                    }
                }

                Console.WriteLine("n) Create New Forum");
                Console.WriteLine("x) Exit");
                Console.Write("Please enter your choice: ");
                string input = Console.ReadLine();

                // Check if number input is a forum number that exists
                if (int.TryParse(input, out int n) == true)
                {
                    int number = int.Parse(input);
                    if (number > forums.Count)
                    {
                        Console.WriteLine($"Forum #{number} doesn't exist! Please select a proper forum number!");
                    }
                    else
                    {
                        Console.WriteLine();
                        PrintForumMenu(forums[number - 1]);
                    }
                }
                // Create a new forum
                else if (input == "n")
                {
                    CreateNewForum(forums);
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
                Console.WriteLine($"Forum - {forum.ForumName}");
                if (forum.topics.Count != 0)
                {
                    for (int i = 0; i < forum.topics.Count; i++)
                    {
                        Console.WriteLine($"{forum.topics[i].TopicID}) Topic - {forum.topics[i].TopicName} (Posted on {forum.topics[i].TopicDate})");
                    }
                }

                Console.WriteLine("n) Create New Topic");
                Console.WriteLine("b) Back to Main Menu");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int b) == true)
                {
                    int number = int.Parse(input);

                    if (number > forum.topics.Count)
                    {
                        Console.WriteLine("That topic doesn't exist! Please select a proper topic number!");
                    }
                    else
                    {
                        Console.WriteLine();
                        PrintTopicMenu(forum.topics[number - 1]);
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
                if (topic.replies.Count != 0)
                {
                    for (int i = 0; i < topic.replies.Count; i++)
                    {
                        Console.WriteLine($"Reply ({topic.replies[i].ReplyDate}): {topic.replies[i].ReplyContent}");
                    }
                }
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

        static void CreateNewForum(List<Forum> forums)
        {
            Console.Write("Please enter the forum name: ");
            string name = Console.ReadLine();

            forums.Add(new Forum(name));
        }

        static void CreateNewTopic(Forum forum)
        {
            Console.Write("Please enter the topic name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter the topic content: ");
            string content = Console.ReadLine();

            forum.AddTopic(name, content);
        }

        static void CreateNewReply(Topic topic)
        {
            Console.Write("Please enter the reply: ");
            string content = Console.ReadLine();

            topic.AddReply(content);
        }
    }
}
