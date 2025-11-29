using CasinoHeyGIA.Domain.Interfaces;
using CasinoHeyGIA.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasinoHeyGIA.Infraestructure.Dapper
{
    public class DapperServicerepository(IConfiguration _configuration) : IUserService
    {
        
        private IDbConnection CreateConnection()
        {
            var _connection = _configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            return new SqlConnection(_connection);
        }
        public async Task<Usuario>GetUser(int idUsuario)
        {
            using var connection = CreateConnection();

            var parametros = new DynamicParameters();
            parametros.Add("@id", idUsuario);

            return (Usuario)await connection.QueryAsync<Usuario>(
                "GetUser",
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
