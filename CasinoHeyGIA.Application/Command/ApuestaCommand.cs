using CasinoHeyGIA.Application.Models;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class ApuestaCommand : IRequest<string>
    {
        public ApuestaRequest Request { get; set; }
    }
}
