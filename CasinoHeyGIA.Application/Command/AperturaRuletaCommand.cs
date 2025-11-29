using CasinoHeyGIA.Application.Models;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class AperturaRuletaCommand : IRequest<AperturaRuletaResponse>
    {
        public AperturaRuletaRequest Request { get; set; }
    }
}
