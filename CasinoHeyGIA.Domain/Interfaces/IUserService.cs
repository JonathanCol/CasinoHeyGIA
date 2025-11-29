using CasinoHeyGIA.Domain.Models;
namespace CasinoHeyGIA.Domain.Interfaces
{
    public interface IUserService
    {
         Task<Usuario> GetUser(int idUsuario);
    }
}
