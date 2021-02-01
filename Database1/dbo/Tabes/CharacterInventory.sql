CREATE TABLE [dbo].[CharacterInventory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CharacterId] NVARCHAR(128) NOT NULL,
    [ItemsId] INT NOT NULL, 
    [ItemQTY] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_CharacterInventory_ToItems] FOREIGN KEY (ItemsId) REFERENCES Items(Id), 
    CONSTRAINT [FK_CharacterInventory_ToDnDUser] FOREIGN KEY (CharacterId) REFERENCES DnDUser([Id])
    
)
