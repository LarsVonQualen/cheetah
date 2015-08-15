CREATE TABLE [dbo].[Users] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Username]  NVARCHAR (255)   NOT NULL,
    [CreatedAt] DATETIME         NOT NULL,
    [ClientId]  UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    CONSTRAINT [PK_Users_UserId] PRIMARY KEY CLUSTERED ([UserId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_Users_UserId]
    ON [dbo].[Users]([UserId] ASC);

