CREATE PROCEDURE [dbo].[MovieGenre_GetAll]
	
AS
Begin
	set nocount on;

	Select *
	from dbo.MovieGenre;
end