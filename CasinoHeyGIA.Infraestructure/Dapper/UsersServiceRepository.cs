using CasinoHeyGIA.Domain.Interfaces;
using CasinoHeyGIA.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasinoHeyGIA.Infraestructure.Dapper
{
    public class UsersServiceRepository(IConfiguration _configuration) : IUserRepository
    {
        
        private IDbConnection CreateConnection()
        {
            var _connection = _configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            return new SqlConnection(_connection);
        }
        public async Task<List<Usuario>>GetUserAsync(int idUsuario)
        {
            using var connection = CreateConnection();
            connection.Open();
            var parametros = new DynamicParameters();
            parametros.Add("@id", idUsuario);

            return (List<Usuario>)await connection.QueryAsync<Usuario>(
                "GetUser",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }
    }
}
