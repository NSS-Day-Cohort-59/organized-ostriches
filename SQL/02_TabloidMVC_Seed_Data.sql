USE [TabloidMVC]
GO

SET IDENTITY_INSERT [UserType] ON
INSERT INTO [UserType] ([ID], [Name]) VALUES (1, 'Admin'), (2, 'Author');
SET IDENTITY_INSERT [UserType] OFF


SET IDENTITY_INSERT [Category] ON
INSERT INTO [Category] ([Id], [Name]) 
VALUES (1, 'Technology'), (2, 'Close Magic'), (3, 'Politics'), (4, 'Science'), (5, 'Improv'), 
	   (6, 'Cthulhu Sightings'), (7, 'History'), (8, 'Home and Garden'), (9, 'Entertainment'), 
	   (10, 'Cooking'), (11, 'Music'), (12, 'Movies'), (13, 'Regrets');
SET IDENTITY_INSERT [Category] OFF


SET IDENTITY_INSERT [Tag] ON
INSERT INTO [Tag] ([Id], [Name])
VALUES (1, 'C#'), (2, 'JavaScript'), (3, 'Cyclopean Terrors'), (4, 'Family');
SET IDENTITY_INSERT [Tag] OFF

SET IDENTITY_INSERT [UserProfile] ON
INSERT INTO [UserProfile] (
	[Id], [FirstName], [LastName], [DisplayName], [Email], [CreateDateTime], [ImageLocation], [UserTypeId])
VALUES (1, 'Admina', 'Strator', 'admin', 'admin@example.com', SYSDATETIME(), NULL, 1);
SET IDENTITY_INSERT [UserProfile] OFF

SET IDENTITY_INSERT [Post] ON
INSERT INTO [Post] (
	[Id], [Title], [Content], [ImageLocation], [CreateDateTime], [PublishDateTime], [IsApproved], [CategoryId], [UserProfileId])
VALUES (
	1, 'C# is the Best Language', 
'There are those' + char(10) + 'who do not believe' + char(10) + 'C# is the best.' + char(10) + 'They are wrong.',
    'https://gizmodiva.com/wp-content/uploads/2017/10/SCOTT-A-WOODWARD_1SW1943-1170x689.jpg',SYSDATETIME(), SYSDATETIME(), 1, 1, 1);
SET IDENTITY_INSERT [Post] OFF
