CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
begin
set nocount on;
	select Id,CharacterName
	from dbo.DnDUser
	where Id =@Id;
end

