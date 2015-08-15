CREATE TABLE [dbo].[PasswordHashes] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Hash]      NVARCHAR (MAX)   NOT NULL,
    [CreatedAt] DATETIME         DEFAULT (getutcdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PasswordHashes_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
    UNIQUE NONCLUSTERED ([UserId] ASC),
    CONSTRAINT [UQ_PasswordHashes_UserId] UNIQUE NONCLUSTERED ([UserId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PasswordHashes_UserId]
    ON [dbo].[PasswordHashes]([UserId] ASC);

