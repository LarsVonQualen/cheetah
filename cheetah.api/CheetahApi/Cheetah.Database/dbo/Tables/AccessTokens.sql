CREATE TABLE [dbo].[AccessTokens] (
    [Id]        INT              IDENTITY (1, 1) NOT NULL,
    [UserId]    UNIQUEIDENTIFIER NOT NULL,
    [Token]     NVARCHAR (MAX)   NOT NULL,
    [Expires]   DATETIME         NOT NULL,
    [CreatedAt] DATETIME         DEFAULT (getutcdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccessTokens_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [UQ_AccessTokens_UserId] UNIQUE NONCLUSTERED ([UserId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_AccessTokens_UserId]
    ON [dbo].[AccessTokens]([UserId] ASC);

