CREATE TABLE [dbo].[Addresses] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Street]        NVARCHAR (MAX)   NULL,
    [City]          NVARCHAR (MAX)   NULL,
    [ZipCode]       NVARCHAR (MAX)   NULL,
    [Country]       NVARCHAR (MAX)   NULL,
    [CountryCode]   NVARCHAR (MAX)   NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CratedBy]      UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

