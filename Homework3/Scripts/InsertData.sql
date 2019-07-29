SET IDENTITY_INSERT Forums ON 
INSERT INTO Forums (ForumId,ForumName) VALUES (1, N'CS 4220 Database Systems');
INSERT INTO Forums (ForumId,ForumName) VALUES (2, N'CS 4661 Data Science');
SET IDENTITY_INSERT Forums OFF
GO

SET IDENTITY_INSERT Topics ON 
INSERT INTO Topics (TopicId, TopicName, TopicContent, TopicDate, ForumId) VALUES (1, N'Homework 1', N'Create a database using MYSQL.', '2019-07-03', 1);
INSERT INTO Topics (TopicId, TopicName, TopicContent, TopicDate, ForumId) VALUES (2, N'Lab 1', N'Create a relational schema.', '2019-07-03', 1);
INSERT INTO Topics (TopicId, TopicName, TopicContent, TopicDate, ForumId) VALUES (3, N'Homework 1', N'Implement Decision Tree algorithm.', '2019-07-01', 2);
INSERT INTO Topics (TopicId, TopicName, TopicContent, TopicDate, ForumId) VALUES (4, N'Lab 1', N'Implement Random Forest algorithm.', '2019-07-03', 2);
SET IDENTITY_INSERT Topics OFF 

GO

SET IDENTITY_INSERT Replies ON
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (1, N'How do I do this homework?', '2019-07-03', 1);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (2, N'Look at your book and implement the database.', '2019-07-03', 1);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (3, N'How do I do this lab?', '2019-07-03', 2);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (4, N'By looking at the book for examples.', '2019-07-03', 2);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (5, N'How do I do this homework?', '2019-07-03', 3);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (6, N'Follow the example that Dr.Mo sent us.', '2019-07-03', 3);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (7, N'How do I do this lab?', '2019-07-03', 4);
INSERT INTO Replies (ReplyId, ReplyContent, ReplyDate, TopicId) VALUES (8, N'The lab is really close the the example in the powerpoint slides.', '2019-07-03', 4);
SET IDENTITY_INSERT Replies OFF

GO
