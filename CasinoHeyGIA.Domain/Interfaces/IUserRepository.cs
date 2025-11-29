using CasinoHeyGIA.Domain.Models;
namespace CasinoHeyGIA.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Usuario>> GetUserAsync(int idUsuario);
        Task UpdateAmountAsync(decimal valor, int idUsuario);
    }
}
