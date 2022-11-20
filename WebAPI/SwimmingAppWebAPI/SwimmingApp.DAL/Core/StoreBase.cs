using Dapper;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingApp.DAL.Core
{
    public class StoreBase
    {
        protected IDbTransaction Transaction;

        public StoreBase()
        { }

        public StoreBase(IDbConnection connection)
        {
            DbConnection = connection;
        }

        public static bool HasRows(SqlMapper.GridReader reader)
        {
            if (reader == null)
                return false;
            var internalReader = (SqlDataReader)typeof(SqlMapper.GridReader)
                .GetField("reader", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(reader);
            return internalReader != null && internalReader.HasRows;
        }

        public IDbConnection CreateNewConnection()
        {
            DbConnection = SqlConnection;
            return DbConnection;
        }

        public IDbConnection DbConnection { get; protected set; }

        public IDbConnection GetConnection()
        {
            if (DbConnection != null)
                return null;
            return SqlConnection;
        }

        protected IDbConnection GetWorkConnection(IDbConnection connect)
        {
            return connect ?? DbConnection;
        }


        public void SetConnection(IDbConnection connection)
        {
            DbConnection = connection;
        }

        public IDbTransaction BeginTransaction()
        {
            if (DbConnection.State != ConnectionState.Open)
                DbConnection.Open();
            var transaction = DbConnection.BeginTransaction();
            SetTransaction(transaction);
            return transaction;
        }

        public void SetTransaction(IDbTransaction transaction)
        {
            Transaction = transaction;
        }

        protected async Task<int> DeleteAsync(string procedureName, object param, CommandType? commandType = CommandType.StoredProcedure)
        {
            using (var connect = GetConnection())
            {
                var conn = connect ?? DbConnection;
                var query = await conn.QueryAsync(procedureName, param, commandType: commandType, transaction: Transaction);
                var result = query.FirstOrDefault();
                if (result == null)
                    return 0;
                return Convert.ToInt32(result.RowCount);
            }
        }

        protected async Task<T> FindAsync<T>(string procedureName, object param, CommandType? commandType = CommandType.StoredProcedure)
        {
            using (var connect = GetConnection())
            {
                var conn = connect ?? DbConnection;
                var result = await conn.QueryAsync<T>(procedureName, param, Transaction, commandType: commandType);
                return result.FirstOrDefault();
            }
        }

        protected async Task<IEnumerable<T>> GetAsync<T>(string procedureName, object param = null, CommandType? commandType = CommandType.StoredProcedure, int? commandTimeout = null)
        {
            using (var connect = GetConnection())
            {
                var conn = connect ?? DbConnection;
                var result = await conn.QueryAsync<T>(procedureName, param, commandType: commandType, transaction: Transaction, commandTimeout: commandTimeout);
                return result;
            }
        }

        protected async Task<int> UpdateAsync(string procedureName, object param, CommandType? commandType = CommandType.StoredProcedure)
        {
            using (var connect = GetConnection())
            {
                var conn = connect ?? DbConnection;
                var query = await conn.QueryAsync(procedureName, param, commandType: commandType, transaction: Transaction);
                var result = query.FirstOrDefault();
                if (result == null)
                    return 0;
                return Convert.ToInt32(result.RowCount);
            }
        }

        protected async Task<T> GetResultAsync<T>(string procedureName, object param, CommandType? commandType = CommandType.StoredProcedure) where T : IConvertible
        {
            using (var connect = GetConnection())
            {
                var conn = connect ?? DbConnection;
                var query = await conn.QueryAsync(procedureName, param, commandType: commandType, transaction: Transaction);
                var result = query.FirstOrDefault();
                return (T)Convert.ChangeType(result.Result, typeof(T));
            }
        }

        //protected async Task<DbInsertResult> InsertAsync(string procedureName, object param, CommandType? commandType = CommandType.StoredProcedure)
        //{
        //    using (var connect = GetConnection())
        //    {
        //        var conn = connect ?? DbConnection;
        //        var query = await conn.QueryAsync(procedureName, param, commandType: commandType, transaction: Transaction);
        //        var result = query.FirstOrDefault();
        //        if (result == null)
        //            return new DbInsertResult(0, null, null);
        //        var rowCount = Convert.ToInt32(result.RowCount);
        //        if (rowCount > 0)
        //            return new DbInsertResult(rowCount, result.Id, result);
        //        return new DbInsertResult(rowCount, null, result);
        //    }
        //}

        public IDbTransaction GetTransaction()
        {
            return Transaction;
        }

        public IDbConnection SqlConnection =>
            new SqlConnection(ConfigurationManager.AppSettings["SwimmingAplication"].ToString());
    }



    public static class StoreBaseExtensions
    {
        public static async Task<TResult> StoreExecuteAsync<TResult, TSource>(this TSource source, Func<IDbConnection, IDbTransaction, Task<TResult>> execFunctionDelegate) where TSource : StoreBase
        {
            using (var connect = source.GetConnection())
            {
                var conn = connect ?? source.DbConnection;
                var transaction = source.GetTransaction();

                var res = await execFunctionDelegate.Invoke(conn, transaction);
                return res;
            }
        }
    }
}

