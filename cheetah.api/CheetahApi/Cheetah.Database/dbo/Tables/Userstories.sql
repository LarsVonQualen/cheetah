CREATE TABLE [dbo].[Userstories] (
    [Id]              INT              IDENTITY (1, 1) NOT NULL,
    [Identity]        INT              NOT NULL,
    [Story]           NVARCHAR (MAX)   NULL,
    [Risks]           NVARCHAR (MAX)   NULL,
    [AcceptCriterias] NVARCHAR (MAX)   NULL,
    [CreatedAt]       DATETIME         NOT NULL,
    [CreatedBy]       UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt]   DATETIME         NOT NULL,
    [LastUpdatedBy]   UNIQUEIDENTIFIER NOT NULL,
    [SprintId]        INT              NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

