using CasinoHeyGIA.Application.Models;
using MediatR;
namespace CasinoHeyGIA.Application.Command
{
    public class CierreRuletaCommand : IRequest<CierreRuletaResponse>
    {
        public CierreRuletaRequest Request { get; set; }
    }
}
