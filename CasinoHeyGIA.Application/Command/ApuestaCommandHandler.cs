using CasinoHeyGIA.Application.Models;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class ApuestaCommandHandler : IRequestHandler<ApuestaCommand, ApuestaResponse>
    {
        public Task<ApuestaResponse> Handle(ApuestaCommand request, CancellationToken cancellationToken)
        {
            ApuestaResponse response = new ApuestaResponse();

            return Task.FromResult(response);
        }
    }
}
