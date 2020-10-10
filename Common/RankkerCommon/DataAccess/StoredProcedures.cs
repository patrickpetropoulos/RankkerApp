namespace RankkerCommon.DataAccess
{
    public static class StoredProcedures
    {
        public const string MOVIE_GETALL = "dbo.Movie_GetAll";
        public const string MOVIE_GETBYTMDBID_WITHGENRES = "Movie_GetByTmdbId_WithGenres";
        public const string MOVIE_INSERT = "dbo.Movie_Insert";

        public const string MOVIEGENRE_GETALL = "dbo.MovieGenre_GetAll";
        public const string MOVIEGENRE_INSERT = "dbo.MovieGenre_Insert";

        public const string MOVIEGENREREL_INSERT = "dbo.MovieGenreRel_Insert";
    }
}