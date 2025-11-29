using CasinoHeyGIA.Application.Models;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class RuletaApuestaCommand : IRequest<string>
    {
        public RuletaApuestaRequest Request { get; set; }
    }
}
