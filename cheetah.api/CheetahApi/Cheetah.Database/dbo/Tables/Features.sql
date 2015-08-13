CREATE TABLE [dbo].[Features] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Label]         NVARCHAR (MAX)   NULL,
    [Name]          NVARCHAR (MAX)   NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

