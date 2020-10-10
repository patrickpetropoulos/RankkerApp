using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;

namespace RankkerCommon.DataAccess
{
    public interface ISqlDataAccess : IDisposable
    {
        void StartTransaction(string connectionString);
        List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        Task<SqlMapper.GridReader> LoadDataFromMultipleQuery<U>(string storedProcedure, U parameters);
        Task SaveDataInTransactionAsync<T>(string storedProcedure, T parameters);
        Task<int> InsertSingleAndReturnId<T>(string storedProcedure, T parameters);
        void CommitTransaction();
        void RollbackTransaction();
    }
}