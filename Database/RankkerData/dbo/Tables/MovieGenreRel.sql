CREATE TABLE [dbo].[MovieGenreRel]
(
	[MovieId] BIGINT NOT NULL,
	[MovieGenreId] INT NOT NULL,
	CONSTRAINT [moviegenrerel_movieid] UNIQUE NONCLUSTERED (
		[MovieId], [MovieGenreId]
	),
	CONSTRAINT [FK_MovieGenreRel_ToMovie] FOREIGN KEY ([MovieId]) REFERENCES Movie(Id), 
    CONSTRAINT [FK_MovieGenreRel_ToMovieGenre] FOREIGN KEY ([MovieGenreId]) REFERENCES MovieGenre(Id)
)
