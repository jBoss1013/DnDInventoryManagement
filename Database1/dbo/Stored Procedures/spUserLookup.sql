CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
	select FirstName,LastName, EmailAddress
	from dbo.DndUser
	where Id =@id;
