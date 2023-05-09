using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataManagerLibrary.DbAccess;
public class MySQLDataAccess : IDataAccess
{
    private readonly IConfiguration _config;

    public MySQLDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        using IDbConnection connection = new MySqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
