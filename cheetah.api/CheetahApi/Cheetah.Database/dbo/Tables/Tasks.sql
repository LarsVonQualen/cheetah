CREATE TABLE [dbo].[Tasks] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Identity]      INT              NOT NULL,
    [Summary]       NVARCHAR (MAX)   NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [Estimate]      INT              DEFAULT ((0)) NOT NULL,
    [Remaining]     INT              DEFAULT ((0)) NOT NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

