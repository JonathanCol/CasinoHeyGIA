using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class RuletaCierreController(IMediator _mediator) : Controller
    {
        [HttpPost("/CierreRuleta")]
        public async Task<ActionResult<string>> CierreRuleta(
            [FromBody] RuletaCierreAux request,
            [FromHeader(Name = "Id_usuario")] string idUsuario = null
            )
        {
            RuletaCierreRequest request1 = new RuletaCierreRequest()
            {
                Id_Ruleta = request.Id_Ruleta,
                idUsuario = idUsuario
            };
            var command = new RuletaCierreCommand()
            {
                Request = request1
            };
            var response = await _mediator.Send(command);
            return this.Ok(response);
        }
    }
}
