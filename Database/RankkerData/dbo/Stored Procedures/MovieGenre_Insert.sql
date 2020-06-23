CREATE PROCEDURE [dbo].[MovieGenre_Insert]
	@Name nvarchar(50),
	@Id INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT  INTO dbo.MovieGenre ([Name], Id)
    VALUES  (@Name, @Id);
END
