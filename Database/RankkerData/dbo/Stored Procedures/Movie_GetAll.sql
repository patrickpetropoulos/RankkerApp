CREATE PROCEDURE [dbo].[Movie_GetAll]
	
AS
Begin
	set nocount on;

	Select *
	from dbo.Movie;
end
