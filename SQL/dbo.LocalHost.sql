﻿CREATE TABLE [dbo].[Agent] 
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [command] NVARCHAR(50) NULL, 
    [result] NVARCHAR(50) NULL, 
    [executionTimeStamp] DATETIME NULL
)

INSERT INTO [dbo].[Agent] ([Id], [command], [result], [executionTimeStamp]) VALUES (1, N'hostname', N'DevFluence-DBN1', N'2018-05-28 19:45:37')
INSERT INTO [dbo].[Agent] ([Id], [command], [result], [executionTimeStamp]) VALUES (2, N'hostname', N'DevFluence-DBN2', N'2018-06-28 19:45:37')