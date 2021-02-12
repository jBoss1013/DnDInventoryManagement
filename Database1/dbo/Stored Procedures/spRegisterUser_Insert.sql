CREATE PROCEDURE [dbo].[spRegisterUser_Insert]
	@Id nvarchar(128),
	@UserName nvarchar(50),
	@Email nvarchar(256),
	@FirstName nvarchar (50),
	@LastName nvarchar (50),
	@Password nvarchar (50),
	@ConfirmPassword nvarchar (50)
AS
begin
	set nocount on;
	insert dbo.DnDUser(Id,UserName)
	values (@Id,@UserName);
end

