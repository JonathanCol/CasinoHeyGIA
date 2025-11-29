using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using CasinoHeyGIA.Domain.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace CasinoHeyGIA.Application.Command
{
    public class RuletaCierreCommandHandler(ICacheService _cacheService, IUserRepository _userRepository) : IRequestHandler<RuletaCierreCommand, RuletaCierreResponse>
    {
        public async Task<RuletaCierreResponse> Handle(RuletaCierreCommand request, CancellationToken cancellationToken)
        {
            RuletaCierreResponse response = new RuletaCierreResponse();
            var apuesta = _cacheService.GetAsync($"{request.Request.Id_Ruleta}-Apuesta");
            var apuestaDeserilizada = JsonConvert.DeserializeObject<RuletaApuestaResponse>(apuesta);

            var monto = apuestaDeserilizada.Monto;
            var ruleta = Random.Shared.Next(0, 36);
            if (ruleta.Equals(apuestaDeserilizada.Numero))
            {
                var numero = apuestaDeserilizada.Numero % 2;
                if (numero.Equals(0))
                {
                    monto = apuestaDeserilizada.Monto * 5;
                    await _userRepository.UpdateAmountAsync(monto, int.Parse(request.Request.idUsuario));
                    response.response = $"Has Ganado por un valor de: {monto}";
                }
                else
                {
                    monto = apuestaDeserilizada.Monto * 1.8m;
                    await _userRepository.UpdateAmountAsync(monto, int.Parse(request.Request.idUsuario));
                    response.response = $"Has Ganado por un valor de: {monto}";
                }
            }
            else
            {
                response.response = $"Has perdido la apuesta";
            }
            return response;
        }
    }
}
