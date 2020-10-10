using System.Collections.Generic;
using System.Threading.Tasks;
using RankkerCommon.Models;

namespace RankkerCommon.ModelDataAccess
{
    public interface IMovieGenreData
    {
        List<MovieGenre> GetAllMovieGenres(string connectionString);
        Task InsertMovieGenre(string connectionString, MovieGenre movieGenre);
    }
}