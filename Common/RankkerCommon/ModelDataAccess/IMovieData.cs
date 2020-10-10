using System.Collections.Generic;
using System.Threading.Tasks;
using RankkerCommon.Models;

namespace RankkerCommon.ModelDataAccess
{
    public interface IMovieData
    {
        List<Movie> GetAllMovies(string connectionString);
        List<Movie> GetAllMoviesAndGenres(string connectionString);
        Task<Movie> InsertMovieAndGenres(string connectionString, Movie movie);
        Task<Movie> GetMovieAndGenresById(string connectionString, long id);
    }
}