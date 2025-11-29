using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class RuletaApuestaController(IMediator _mediator) : Controller
    {
        [HttpPut("/Apuesta")]
        public async Task<ActionResult<string>> Apuesta(
            [FromBody] RuletaApuestaRequestAux request,
            [FromHeader(Name = "Id_usuario")] string idUsuario = null
            )
        {
            RuletaApuestaRequest request1 = new RuletaApuestaRequest()
            {
                IdRuleta = request.IdRuleta,
                Monto = request.MontoApuesta,
                Numero = request.Numero,
                IdUsuario = idUsuario,
                Color = request.Color
            };
            var command = new RuletaApuestaCommand()
            {
                Request = request1
            };
            var response = await _mediator.Send(command);
            return this.Ok(response);
        }
    }
}
