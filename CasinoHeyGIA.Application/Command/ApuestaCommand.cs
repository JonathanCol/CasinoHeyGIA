using CasinoHeyGIA.Application.Models;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class ApuestaCommand : IRequest<ApuestaResponse>
    {
        public ApuestaRequest Request { get; set; }
    }
}
