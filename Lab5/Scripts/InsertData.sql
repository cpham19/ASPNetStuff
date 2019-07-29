
SET IDENTITY_INSERT Contacts ON 
INSERT INTO Contacts (ContactId, Name, PhoneNumber) VALUES (1, N'John', N'123-456-1450');
INSERT INTO Contacts (ContactId, Name, PhoneNumber) VALUES (2, N'Jane', N'123-456-1450');
INSERT INTO Contacts (ContactId, Name, PhoneNumber) VALUES (3, N'Bill', N'123-456-1450');
INSERT INTO Contacts (ContactId, Name, PhoneNumber) VALUES (4, N'Beth', N'123-456-1450');
SET IDENTITY_INSERT Contacts OFF

GO
