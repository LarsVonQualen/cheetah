CREATE TABLE [dbo].[RefreshTokens] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Token]     NVARCHAR (MAX)   NOT NULL,
    [CreatedAt] DATETIME         DEFAULT (getutcdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RefreshTokens_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [UQ_RefreshTokens_UserId] UNIQUE NONCLUSTERED ([UserId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_RefreshTokens_UserId]
    ON [dbo].[RefreshTokens]([UserId] ASC);

