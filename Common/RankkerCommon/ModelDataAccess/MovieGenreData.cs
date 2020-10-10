using System.Collections.Generic;
using System.Threading.Tasks;
using RankkerCommon.AutoMapper;
using RankkerCommon.DataAccess;
using RankkerCommon.DTOs;
using RankkerCommon.Models;

namespace RankkerCommon.ModelDataAccess
{
    public class MovieGenreData : IMovieGenreData
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public MovieGenreData(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }



        public List<MovieGenre> GetAllMovieGenres(string connectionString)
        {
            var genres = new List<MovieGenre>();
            try
            {
                _sqlDataAccess.StartTransaction(connectionString);

                genres = _sqlDataAccess.LoadDataInTransaction<MovieGenre, dynamic>(StoredProcedures.MOVIEGENRE_GETALL,
                    new { });
            }
            catch
            {
                //TODO log error
            }

            return genres;
        }

        public async Task InsertMovieGenre(string connectionString, MovieGenre movieGenre)
        {
            var movieGenreDTO = AutoMapperConfiguration.Mapper.Map<MovieGenreDTO>(movieGenre);
            try
            {
                _sqlDataAccess.StartTransaction(connectionString);

                await _sqlDataAccess.SaveDataInTransactionAsync(StoredProcedures.MOVIEGENRE_INSERT, movieGenreDTO);

                _sqlDataAccess.CommitTransaction();
            }
            catch
            {
                //TODO log error
            }

        }
    }
}