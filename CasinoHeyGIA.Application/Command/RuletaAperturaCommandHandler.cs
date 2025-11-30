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

            if (string.IsNullOrEmpty(id))
            {
                response.Estado = "Error";
                response.Message = "El valor de id no puede ser vacio o nulo";
                return Task.FromResult(response);

            }
            var valor = _cacheService.GetAsync(id);
            if (!string.IsNullOrEmpty(valor))
            {
                response.Estado = "OK";
                response.Message = "Apertura de ruleta exitosa";
            }
            else
            {
                response.Estado = "Error";
                response.Message = "Id de ruleta no encontrado";
            }
            return Task.FromResult(response);
        }
    }
}
