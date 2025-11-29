using CasinoHeyGIA.Application.Models;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class RuletaAperturaCommand : IRequest<RuletaAperturaResponse>
    {
        public RuletaAperturaRequest Request { get; set; }
    }
}
