using CasinoHeyGIA.Application.Interfaces;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class CrearRuletaCommandHandler(ICacheService _cacheService) : IRequestHandler<CrearRuletaCommand, string>
    {
        public Task<string> Handle(CrearRuletaCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();
            _cacheService.SetAsync(id, id);
            return Task.FromResult(id);
        }
    }
}
