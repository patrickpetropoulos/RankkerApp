using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace RankkerCommon.DataAccess
{
    public  class SqlDataAccess : ISqlDataAccess
    {
//        public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionString)
//        {
//            using (IDbConnection connection = new SqlConnection(connectionString))
//            {
//                List<T> rows = connection.Query<T>(storedProcedure, parameters,
//                    commandType: CommandType.StoredProcedure).ToList();
//
//                return rows;
//            }
//        }
//
//        public void SaveData<T>(string storedProcedure, T parameters, string connectionString)
//        {
//
//            using (IDbConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Execute(storedProcedure, parameters,
//                    commandType: CommandType.StoredProcedure);
//            }
//        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public void StartTransaction(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();

            isClosed = false;
        }

        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();

            return rows;
        }

        public async Task<SqlMapper.GridReader> LoadDataFromMultipleQuery<U>(string storedProcedure, U parameters)
        {
            return await _connection.QueryMultipleAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
        
        public async Task SaveDataInTransactionAsync<T>(string storedProcedure, T parameters)
        {
            await _connection.ExecuteAsync(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public async Task<int> InsertSingleAndReturnId<T>(string storedProcedure, T parameters)
        {
            var insertedId = (await _connection.QueryAsync<int>(storedProcedure,
                parameters, commandType: CommandType.StoredProcedure, transaction: _transaction)).Single();

            return insertedId;
        }

        private bool isClosed = false;

        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();

            isClosed = true;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();

            isClosed = true;
        }

        public void Dispose()
        {
            if (isClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    // TODO - Log this issue
                }
            }

            _transaction = null;
            _connection = null;
        }

        // Open connect/start transaction method
        // load using the transaction
        // save using the transaction
        // Close connection/stop transaction method
        // Dispose
    }
}