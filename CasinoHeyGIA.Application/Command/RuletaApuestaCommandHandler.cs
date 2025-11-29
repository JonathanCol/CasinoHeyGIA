using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using CasinoHeyGIA.Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CasinoHeyGIA.Application.Command
{
    public class RuletaApuestaCommandHandler(IUserRepository _userRepository, ICacheService _cacheService) : IRequestHandler<RuletaApuestaCommand, string>
    {
        public async Task<string> Handle(RuletaApuestaCommand request, CancellationToken cancellationToken)
        {
            
            var usuario = await _userRepository.GetUserAsync(int.Parse(request.Request.IdUsuario));

            RuletaApuestaResponse response = new RuletaApuestaResponse() 
            {
                Nombre = usuario[0].Nombre,
                Monto = request.Request.Monto,
                Numero = request.Request.Numero.ToString(),
                Color = request.Request.Color,
            };

            if (usuario[0].Saldo < request.Request.Monto)
            {
                return "Saldo insuficiente para la apuesta";
            }
            else
            {
                _cacheService.SetAsync($"{request.Request.IdRuleta}-Apuesta", JsonConvert.SerializeObject(response));
                return "Apuesta realizada";
            }
        }
    }
}
