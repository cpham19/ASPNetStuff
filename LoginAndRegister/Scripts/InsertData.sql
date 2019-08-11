SET IDENTITY_INSERT Persons ON 
INSERT INTO Persons (PersonId, Name, Username, Password, IsAdmin) VALUES (1, N'John', N'John', N'abcd', 1);
INSERT INTO Persons (PersonId, Name, Username, Password) VALUES (2, N'Calvin', N'Calvin', N'abcd');
SET IDENTITY_INSERT Persons OFF

GO
