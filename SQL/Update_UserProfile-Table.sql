CREATE TABLE [dbo].[UserProfile] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [DisplayName]    NVARCHAR (50)  NOT NULL,
    [FirstName]      NVARCHAR (50)  NOT NULL,
    [LastName]       NVARCHAR (50)  NOT NULL,
    [Email]          NVARCHAR (555) NOT NULL,
    [CreateDateTime] DATETIME       NOT NULL,
    [ImageLocation]  NVARCHAR (255) NULL,
    [UserTypeId]     INT            NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_UserType] FOREIGN KEY ([UserTypeId]) REFERENCES [dbo].[UserType] ([Id])
);

