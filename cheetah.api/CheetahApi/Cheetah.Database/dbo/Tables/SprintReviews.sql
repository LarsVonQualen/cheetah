CREATE TABLE [dbo].[SprintReviews] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [Review]        NVARCHAR (MAX)   NULL,
    [CreatedAt]     DATETIME         NOT NULL,
    [CreatedBy]     UNIQUEIDENTIFIER NOT NULL,
    [LastUpdatedAt] DATETIME         NOT NULL,
    [LastUpdatedBy] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

