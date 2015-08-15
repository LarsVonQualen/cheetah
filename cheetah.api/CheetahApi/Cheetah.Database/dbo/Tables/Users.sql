CREATE TABLE [dbo].[Users] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Username]  NVARCHAR (255)   NOT NULL,
    [CreatedAt] DATETIME         DEFAULT (getutcdate()) NOT NULL,
    [ClientId]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Users_UserId] UNIQUE NONCLUSTERED ([UserId] ASC),
    CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_UserId]
    ON [dbo].[Users]([UserId] ASC);

