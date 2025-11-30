using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using CasinoHeyGIA.Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;
using System.Drawing;
using System.Security.AccessControl;
using System.Text.Json.Serialization;

namespace CasinoHeyGIA.Application.Command
{
    public class RuletaApuestaCommandHandler(IUserRepository _userRepository, ICacheService _cacheService) : IRequestHandler<RuletaApuestaCommand, string>
    {
        public async Task<string> Handle(RuletaApuestaCommand request, CancellationToken cancellationToken)
        {
            
            var usuario = await _userRepository.GetUserAsync(int.Parse(request.Request.IdUsuario));

            if (usuario.Count() == 0)
            {
                return "Usuario no encontrado";
            }

            if (string.IsNullOrEmpty(request.Request.Numero) && string.IsNullOrEmpty(request.Request.Color))
            {
                return "Parametros invalidos para la apuesta";
            }

            if (int.Parse(request.Request.Numero) > 36 || int.Parse(request.Request.Numero) < 0)
            {
                return "Parametros invalidos para la apuesta";
            }
            RuletaApuestaResponse response = new RuletaApuestaResponse() 
            {
                Nombre = usuario[0].Nombre,
                Monto = request.Request.Monto,
                Numero = request.Request.Numero,
                Color = request.Request.Color,
            };

            bool esValido = Enum.TryParse(request.Request.Color, true, out ColorEnum resultado);
            if (!esValido) 
            {
                return $"El color {request.Request.Color} no es valido";
            }
            if (request.Request.Monto > 10000 || request.Request.Monto <= 0)
            {
                return "El monto de la apuesta debe ser superior a cero y menor a 10000";
            }
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
