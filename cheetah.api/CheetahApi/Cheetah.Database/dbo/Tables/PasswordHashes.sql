CREATE TABLE [dbo].[PasswordHashes] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Hash]      NVARCHAR (MAX)   NOT NULL,
    [CreatedAt] DATETIME         NOT NULL,
    CONSTRAINT [PK_PasswordHashes_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PasswordHashes_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);








GO
CREATE NONCLUSTERED INDEX [IX_PasswordHashes_UserId]
    ON [dbo].[PasswordHashes]([UserId] ASC);

