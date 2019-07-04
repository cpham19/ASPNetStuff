using System;
using System.Collections.Generic;

namespace Homework2
{
    public class Forum
    {
        public int Id { get; set; }
        public string ForumName { get; set; }

        public override string ToString()
        {
            return $"{Id}) Forum - {ForumName}";
        }
    }

    public class Topic
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
        public DateTime TopicDate { get; set; }

        public string TopicContent { get; set; }

        public virtual int ForumID { get; set; }

        public override string ToString()
        {
            return $"{Id}) Topic - {TopicName} (Posted on {TopicDate})";
        }
    }

    public class Reply
    {
        public int Id { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyDate { get; set; }
        public virtual int TopicId { get; set; }

        public override string ToString()
        {
            return $"Reply ({ReplyDate}): {ReplyContent}";
        }
    }

}
