CREATE TABLE [dbo].[Users] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [UserId]        UNIQUEIDENTIFIER NOT NULL,
    [Username]      NVARCHAR (255)   NOT NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [ClientId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [Email]         NVARCHAR (255)   NULL,
    [UserProfileId] INT              NULL,
    CONSTRAINT [PK_Users_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_UserProfiles] FOREIGN KEY ([UserProfileId]) REFERENCES [dbo].[UserProfiles] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [UQ_Users_Email] UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [UQ_USers_UserID] UNIQUE NONCLUSTERED ([UserId] ASC),
    CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);








GO
CREATE NONCLUSTERED INDEX [IX_Users_UserId]
    ON [dbo].[Users]([UserId] ASC);

