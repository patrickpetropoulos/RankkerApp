using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using RankkerCommon.AutoMapper;
using RankkerCommon.DataAccess;
using RankkerCommon.DTOs;
using RankkerCommon.Models;

namespace RankkerCommon.ModelDataAccess
{
    public class MovieData : IMovieData
    {
        private readonly IConfiguration _configuration;
        private readonly ISqlDataAccess _sqlDataAccess;

        public MovieData(IConfiguration configuration, ISqlDataAccess sqlDataAccess)
        {
            _configuration = configuration;
            _sqlDataAccess = sqlDataAccess;
        }
        public List<Movie> GetAllMovies(string connectionString)
        {
            var movies = new List<Movie>();
            try
            {
                _sqlDataAccess.StartTransaction(connectionString);

                movies = _sqlDataAccess.LoadDataInTransaction<Movie, Empty>(StoredProcedures.MOVIE_GETALL, new Empty());

            }
            catch
            {
                //TODO log error
            }

            return movies;
        }

        public List<Movie> GetAllMoviesAndGenres(string connectionString)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Movie> InsertMovieAndGenres(string connectionString, Movie movie)
        {
            try
            {
                _sqlDataAccess.StartTransaction(connectionString);

                var movieDTO = AutoMapperConfiguration.Mapper.Map<MovieDTO>(movie);

                var insertedId = await _sqlDataAccess.InsertSingleAndReturnId(StoredProcedures.MOVIE_INSERT, movieDTO);

                movie.Id = insertedId;

                foreach (var movieGenre in movie.MovieGenres)
                {
                    await _sqlDataAccess.SaveDataInTransactionAsync(StoredProcedures.MOVIEGENREREL_INSERT,
                        new {MovieId = movie.Id, MovieGenreId = movieGenre.Id});
                }

                _sqlDataAccess.CommitTransaction();
            }
            catch(Exception e)
            {
                //TODO log error
                //TODO rollback ????
                Console.WriteLine(e);
            }



            return movie;
        }

        public async Task<Movie> GetMovieAndGenresById(string connectionString, long id)
        {
            Movie movie = null;
            try
            {
                _sqlDataAccess.StartTransaction(connectionString);
                var gridReader =
                    await _sqlDataAccess.LoadDataFromMultipleQuery(StoredProcedures.MOVIE_GETBYTMDBID_WITHGENRES,
                        new {TmdbId = id});
                movie = gridReader.Read<Movie>().Single();
                var genres = gridReader.Read<MovieGenreRelDTO>().ToList();
                movie.MovieGenres = genres.Select(c => new MovieGenre() {Id = c.MovieGenreId, Name = c.MovieGenreName})
                    .ToList();
            }
            catch (Exception e)
            {

            }

            return movie;
        }

//        public Task<Movie> GetMovieAndGenresById(string connectionString, long id)
//        {
//            var sql = @"SELECT m.[Id],m.[Name],m.[Tagline],m.[Overview]
//                ,m.[ReleaseDate],m.[Runtime],m.[Budget],m.[Revenue]
//                ,m.[TmdbId],m.[ImdbId],m.[TmdbPosterPath],m.[TmdbBackdropPath]
//                ,m.[Status],m.[DateUpdated]
//            FROM[Rankker].[dbo].[Movie] m
//              
//
//              select m.[Id] as MovieId, g.[Id] as MovieGenreId, g.[Name] as MovieGenreName
//              from [Rankker].[dbo].[MovieGenre] g
//              inner  join [Rankker].[dbo].[MovieGenreRel] rel on rel.MovieGenreId = g.Id
//              inner join [Rankker].[dbo].[Movie] m on rel.MovieId = m.Id";
//
//
//            try
//            {
//                using (IDbConnection connection = new SqlConnection(connectionString))
//                {
//                    var mapper = connection.QueryMultiple(sql, new {}); //new {DataId = id});
//
//                    var movies = mapper.Read<Movie>().ToDictionary(k => k.Id, v => v);
//                    var genres = mapper.Read<MovieGenreRelDTO>().ToList();
//
//                    foreach (var genreGroup in genres.GroupBy(g => g.MovieId))
//                    {
//                        movies[genreGroup.Key].MovieGenres = genreGroup.ToList().Select(c => new MovieGenre(){Id = c.MovieGenreId, Name = c.MovieGenreName}).ToList();
//                    }
//                    
//                    Console.WriteLine("test");
//
//
//                }
//            }
//            catch (Exception e)
//            {
//
//            }
//
//            return null;
//
//        }
    }
    
}