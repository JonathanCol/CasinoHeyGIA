using CasinoHeyGIA.Application.Models;
using MediatR;
namespace CasinoHeyGIA.Application.Command
{
    public class RuletaCierreCommand : IRequest<RuletaCierreResponse>
    {
        public RuletaCierreRequest Request { get; set; }
    }
}
