using CasinoHeyGIA.Application.Interfaces;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class RuletaCrearCommandHandler(ICacheService _cacheService) : IRequestHandler<RuletaCrearCommand, string>
    {
        public Task<string> Handle(RuletaCrearCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();
            _cacheService.SetAsync(id, id);
            return Task.FromResult(id);
        }
    }
}
