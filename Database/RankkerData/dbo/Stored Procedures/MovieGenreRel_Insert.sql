CREATE PROCEDURE [dbo].[MovieGenreRel_Insert]
	@MovieId int,
	@MovieGenreId int
AS
BEGIN
    SET NOCOUNT ON;
    INSERT  INTO dbo.MovieGenreRel ([MovieId], [MovieGenreId])
    VALUES  (@MovieId, @MovieGenreId);
END
