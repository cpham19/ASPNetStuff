INSERT INTO Forums (ForumName) VALUES (N'CS 4220 Database Systems');
INSERT INTO Forums (ForumName) VALUES (N'CS 4661 Data Science');

GO

INSERT INTO Topics (TopicName, TopicContent, TopicDate, ForumId) VALUES (N'Homework 1', N'Create a database using MYSQL.', '2019-07-03', 1);
INSERT INTO Topics (TopicName, TopicContent, TopicDate, ForumId) VALUES (N'Lab 1', N'Create a relational schema.', '2019-07-03', 1);
INSERT INTO Topics (TopicName, TopicContent, TopicDate, ForumId) VALUES (N'Homework 1', N'Implement Decision Tree algorithm.', '2019-07-01', 2);
INSERT INTO Topics (TopicName, TopicContent, TopicDate, ForumId) VALUES (N'Lab 1', N'Implement Random Forest algorithm.', '2019-07-03', 2);

GO

INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'How do I do this homework?', '2019-07-03', 1);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'Look at your book and implement the database.', '2019-07-03', 1);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'How do I do this lab?', '2019-07-03', 2);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'By looking at the book for examples.', '2019-07-03', 2);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'How do I do this homework?', '2019-07-03', 3);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'Follow the example that Dr.Mo sent us.', '2019-07-03', 3);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'How do I do this lab?', '2019-07-03', 4);
INSERT INTO Replies (ReplyContent, ReplyDate, TopicId) VALUES (N'The lab is really close the the example in the powerpoint slides.', '2019-07-03', 4);

GO
