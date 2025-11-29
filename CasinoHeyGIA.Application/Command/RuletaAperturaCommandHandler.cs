using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using MediatR;
namespace CasinoHeyGIA.Application.Command
{
    public class RuletaAperturaCommandHandler(ICacheService _cacheService) : IRequestHandler<RuletaAperturaCommand, RuletaAperturaResponse>
    {
        public Task<RuletaAperturaResponse> Handle(RuletaAperturaCommand request, CancellationToken cancellationToken)
        {
            RuletaAperturaResponse response = new RuletaAperturaResponse();
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
