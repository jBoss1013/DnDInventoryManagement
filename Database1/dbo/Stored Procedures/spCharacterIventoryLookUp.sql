CREATE PROCEDURE [dbo].[spCharacterIventoryLookUp]
AS
Begin
	set nocount on;
	SELECT ItemsId,ItemQTY
	FROM dbo.CharacterInventory
RETURN
end
