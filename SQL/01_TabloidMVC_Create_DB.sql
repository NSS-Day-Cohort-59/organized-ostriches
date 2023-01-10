USE [master]

IF db_id('TabloidMVC') IS NULl
  CREATE DATABASE [TabloidMVC]
GO

USE [TabloidMVC]
GO


DROP TABLE IF EXISTS [PostReaction];
DROP TABLE IF EXISTS [Reaction];
DROP TABLE IF EXISTS [PostTag];
DROP TABLE IF EXISTS [Tag];
DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [Subscription];
DROP TABLE IF EXISTS [UserProfile];
DROP TABLE IF EXISTS [UserType];
GO


CREATE TABLE [UserType] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(20) NOT NULL
)

CREATE TABLE [UserProfile] (
  [Id] integer PRIMARY KEY IDENTITY,
  [DisplayName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [LastName] nvarchar(50) NOT NULL,
  [Email] nvarchar(555) NOT NULL,
  [CreateDateTime] datetime NOT NULL,
  [ImageLocation] nvarchar(255),
  [UserTypeId] integer NOT NULL,

  CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [UserType] ([Id])
)

CREATE TABLE [Subscription] (
  [Id] integer PRIMARY KEY IDENTITY,
  [SubscriberUserProfileId] integer NOT NULL,
  [ProviderUserProfileId] integer NOT NULL,
  [BeginDateTime] datetime NOT NULL,
  [EndDateTime] datetime,

  CONSTRAINT [FK_Subscription_UserProfile_Subscriber] FOREIGN KEY ([SubscriberUserProfileId])
	REFERENCES [UserProfile] ([Id]),

  CONSTRAINT [FK_Subscription_UserProfile_Provider] FOREIGN KEY ([ProviderUserProfileId])
	REFERENCES [UserProfile] ([Id])
)

CREATE TABLE [Category] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(50) NOT NULL
)

CREATE TABLE [Post] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Title] nvarchar(255) NOT NULL,
  [Content] text NOT NULL,
  [ImageLocation] nvarchar(255),
  [CreateDateTime] datetime NOT NULL,
  [PublishDateTime] datetime,
  [IsApproved] bit NOT NULL,
  [CategoryId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]),
  CONSTRAINT [FK_Post_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)

CREATE TABLE [Comment] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,
  [Subject] nvarchar(255) NOT NULL,
  [Content] text NOT NULL,
  [CreateDateTime] datetime NOT NULL,

  CONSTRAINT [FK_Comment_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)

CREATE TABLE [Tag] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(50) NOT NULL
)

CREATE TABLE [PostTag] (
  [id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [TagId] integer NOT NULL,
  
  CONSTRAINT [FK_PostTag_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [Tag] ([Id])
)

CREATE TABLE [Reaction] (
  [Id] integer PRIMARY KEY IDENTITY,
  [Name] nvarchar(50) NOT NULL,
  [ImageLocation] nvarchar(255) NOT NULL
)

CREATE TABLE [PostReaction] (
  [Id] integer PRIMARY KEY IDENTITY,
  [PostId] integer NOT NULL,
  [ReactionId] integer NOT NULL,
  [UserProfileId] integer NOT NULL,

  CONSTRAINT [FK_PostReaction_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
  CONSTRAINT [FK_PostReaction_Reaction] FOREIGN KEY ([ReactionId]) REFERENCES [Reaction] ([Id]),
  CONSTRAINT [FK_PostReaction_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
)
GO