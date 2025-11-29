using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class ApuestaController(IMediator _mediator) : Controller
    {
        [HttpPut("/Apuesta")]
        public async Task<ActionResult<string>> CreaRuleta(
            [FromBody] ApuestaRequestAux request,
            [FromHeader(Name = "Id_usuario")] string idUsuario = null
            )
        {
            ApuestaRequest request1 = new ApuestaRequest()
            {
                Id_ruleta = request.Id_ruleta,
                Apuesta = request.MontoApuesta,
                Numero = request.Numero,
                IdUsuario = idUsuario
            };
            var command = new ApuestaCommand()
            {
                Request = request1
            };
            var response = await _mediator.Send(command);
            return this.Ok(response);
        }
    }
}
