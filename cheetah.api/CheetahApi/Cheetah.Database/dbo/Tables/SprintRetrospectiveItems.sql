CREATE TABLE [dbo].[SprintRetrospectiveItems] (
    [Id]                    INT              NOT NULL,
    [Description]           NVARCHAR (MAX)   NULL,
    [SprintRetrospectiveId] INT              NOT NULL,
    [CreatedAt]             DATETIME         NOT NULL,
    [CreatedBy]             UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt]         DATETIME         NOT NULL,
    [LastUpdatedBy]         UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

