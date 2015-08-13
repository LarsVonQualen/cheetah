CREATE TABLE [dbo].[SprintRetrospectives] (
    [Id]            INT              NOT NULL,
    [Headline]      NVARCHAR (MAX)   NULL,
    [SprintId]      INT              NOT NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

