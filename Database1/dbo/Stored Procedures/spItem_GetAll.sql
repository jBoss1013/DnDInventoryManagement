CREATE PROCEDURE [dbo].[spItem_GetAll]
AS
begin
	set nocount on;
	SELECT  Id,ItemName,ItemDescription 
	FROM dbo.Items
	Order by ItemName;
end
