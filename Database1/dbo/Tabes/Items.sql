﻿CREATE TABLE [dbo].[Items]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ItemName] NVARCHAR(100) NOT NULL, 
    [ItemDescription] NVARCHAR(MAX) NOT NULL
)
