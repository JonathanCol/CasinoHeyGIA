using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Newtonsoft.Json;

namespace CasinoHeyGIA.Application.Command
{
    public class CierreRuletaCommandHandler(ICacheService _cacheService) : IRequestHandler<CierreRuletaCommand, CierreRuletaResponse>
    {
        public Task<CierreRuletaResponse> Handle(CierreRuletaCommand request, CancellationToken cancellationToken)
        {
            CierreRuletaResponse response = new CierreRuletaResponse();
            var apuesta = _cacheService.GetAsync($"{request.Request.Id_Ruleta}-Apuesta");
            var apuestaDeserilizada = JsonConvert.DeserializeObject<ApuestaResponse>(apuesta);

            var monto = apuestaDeserilizada.Apuesta;
            var ruleta = Random.Shared.Next(0, 36);
            if (ruleta.Equals(apuestaDeserilizada.Numero))
            {
                var numero = apuestaDeserilizada.Numero % 2;
                if (numero.Equals(0))
                {
                    monto = apuestaDeserilizada.Apuesta * 5;
                    response.response = $"Has Ganado por un valor de: {monto}";
                }
                else
                {
                    monto = apuestaDeserilizada.Apuesta * 1.8m;
                    response.response = $"Has Ganado por un valor de: {monto}";
                }
            }
            else
            {
                response.response = $"Has perdido la apuesta";
            }
            throw new NotImplementedException();
        }
    }
}
