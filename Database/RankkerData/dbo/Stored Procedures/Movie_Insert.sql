CREATE PROCEDURE [dbo].[Movie_Insert]
@Id INT, 
@Name NVARCHAR (150), 
@Tagline NVARCHAR (MAX), 
@Overview NVARCHAR (MAX), 
@ReleaseDate DATETIME2, 
@Runtime INT, 
@Budget BIGINT, 
@Revenue BIGINT,
@TmdbId BIGINT, 
@ImdbId NVARCHAR (50), 
@TmdbPosterPath NVARCHAR (500),
@TmdbBackdropPath NVARCHAR (500), 
@Status NVARCHAR (50), 
@DateUpdated DATETIME2 
AS
BEGIN
    SET NOCOUNT ON;
    INSERT  INTO dbo.Movie ([Name], Tagline, Overview, ReleaseDate, Runtime, Budget, Revenue, TmdbId, ImdbId, TmdbPosterPath, TmdbBackdropPath, [Status], DateUpdated)
    VALUES                (@Name, @Tagline, @Overview, @ReleaseDate, @Runtime, @Budget, @Revenue, @TmdbId, @ImdbId, @TmdbPosterPath, @TmdbBackdropPath, @Status, @DateUpdated);
    SELECT CAST(SCOPE_IDENTITY() as int)
END