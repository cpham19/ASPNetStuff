﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework3
{
    public class Forum
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ForumId { get; set; }
        public string ForumName { get; set; }

        public string ModifiedForumName()
        {
            string[] names = ForumName.Split(" ");
            return string.Join("_", names);
        }
 
        public override string ToString()
        {
            return $"{ForumId}) Forum - {ForumName}";
        }

        public List<Topic> Topics { get; set; }
    }

    public class Topic
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public DateTime TopicDate { get; set; }

        public string TopicContent { get; set; }

        public virtual int ForumId { get; set; }

        public override string ToString()
        {
            return $"{TopicId}) Topic - {TopicName} (Posted on {TopicDate})";
        }

        public List<Reply> Replies { get; set; }
    }

    public class Reply
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ReplyId { get; set; }
        public string ReplyContent { get; set; }
        public DateTime ReplyDate { get; set; }
        public virtual int TopicId { get; set; }

        public override string ToString()
        {
            return $"Reply ({ReplyDate}): {ReplyContent}";
        }
    }

}
