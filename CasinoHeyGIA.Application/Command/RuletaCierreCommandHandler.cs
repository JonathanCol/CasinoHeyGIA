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
            var apuesta = _cacheService.GetAsync($"{request.Request.IdRuleta}-Apuesta");
            if (string.IsNullOrEmpty(apuesta))
            {
                throw new ArgumentNullException("Id de ruleta invalido");
            }
            var apuestaDeserilizada = JsonConvert.DeserializeObject<RuletaApuestaResponse>(apuesta);

            var usuario = await _userRepository.GetUserAsync(int.Parse(request.Request.IdUsuario));

            var monto = apuestaDeserilizada.Monto;
            var ruleta = Random.Shared.Next(0, 36);

            if(int.Parse(apuestaDeserilizada.Numero) < 0)
            {
                response.response = "El numero debe ser mayor o igual a 0";
            }
            if (!string.IsNullOrEmpty(apuestaDeserilizada.Numero))
            {
                if (ruleta.Equals(apuestaDeserilizada.Numero))
                {
                    monto = apuestaDeserilizada.Monto * 5 + usuario[0].Saldo;
                    await _userRepository.UpdateAmountAsync(monto, int.Parse(request.Request.IdUsuario));
                    response.response = $"Has Ganado por un valor de: {monto}";
                }
                else
                {
                    monto = usuario[0].Saldo - apuestaDeserilizada.Monto;
                    await _userRepository.UpdateAmountAsync(monto, int.Parse(request.Request.IdUsuario));
                    response.response = $"Has perdido la apuesta";
                }
            }
            if (!string.IsNullOrEmpty(apuestaDeserilizada.Color))
            {
                var color = ruleta % 2 == 0 ? "rojo" : "negro";
                if (color.Equals(apuestaDeserilizada.Color))
                {
                    monto = (apuestaDeserilizada.Monto * 1.8m) + usuario[0].Saldo;
                    await _userRepository.UpdateAmountAsync(monto, int.Parse(request.Request.IdUsuario));
                    response.response = $"Has Ganado por un valor de: {monto}";
                }
                else
                {
                    monto = usuario[0].Saldo - apuestaDeserilizada.Monto;
                    await _userRepository.UpdateAmountAsync(monto, int.Parse(request.Request.IdUsuario));
                    response.response = $"Has perdido la apuesta";
                }
            }
            return response;
        }
    }
}
