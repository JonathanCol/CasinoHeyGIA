using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using MediatR;
namespace CasinoHeyGIA.Application.Command
{
    public class AperturaRuletaCommandHandler(ICacheService _cacheService) : IRequestHandler<AperturaRuletaCommand, AperturaRuletaResponse>
    {
        public Task<AperturaRuletaResponse> Handle(AperturaRuletaCommand request, CancellationToken cancellationToken)
        {
            AperturaRuletaResponse response = new AperturaRuletaResponse();
            var id = request.Request.Id;
            var valor = _cacheService.GetAsync(id);
            if (!string.IsNullOrEmpty(valor))
            {
                response.Estado = "Apertura de ruleta exitosa";
            }
            else
            {
                response.Estado = "Id de ruleta no encontrado";
            }
            return Task.FromResult(response);
        }
    }
}
