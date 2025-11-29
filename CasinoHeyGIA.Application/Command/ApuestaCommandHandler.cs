using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using CasinoHeyGIA.Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CasinoHeyGIA.Application.Command
{
    public class ApuestaCommandHandler(IUserRepository _userRepository, ICacheService _cacheService) : IRequestHandler<ApuestaCommand, string>
    {
        public async Task<string> Handle(ApuestaCommand request, CancellationToken cancellationToken)
        {
            
            var usuario = await _userRepository.GetUserAsync(int.Parse(request.Request.IdUsuario));

            ApuestaResponse response = new ApuestaResponse() 
            {
                Nombre = usuario[0].Nombre,
                Apuesta = usuario[0].Saldo,
                Numero = request.Request.Numero,
            };

            if (usuario[0].Saldo < request.Request.Apuesta)
            {
                return "Saldo insuficiente para la apuesta";
            }
            else
            {
                _cacheService.SetAsync($"{request.Request.Id_Ruleta}-Apuesta", JsonConvert.SerializeObject(response));
                return "Apuesta realizada";
            }
        }
    }
}
