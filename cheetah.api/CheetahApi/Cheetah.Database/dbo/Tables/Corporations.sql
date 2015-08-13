CREATE TABLE [dbo].[Corporations] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX)   NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    [AddressId]     INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

