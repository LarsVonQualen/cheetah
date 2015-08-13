CREATE TABLE [dbo].[Organizations] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX)   NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [CorporationId] INT              NOT NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

