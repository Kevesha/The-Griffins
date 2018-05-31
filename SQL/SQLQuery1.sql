CREATE TABLE [dbo].[Activities] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [target]       NVARCHAR (50) NULL,
    [action]       NVARCHAR (50) NULL,
    [actionResult] NVARCHAR (50) NULL,
	[Timestamp] datetime  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);