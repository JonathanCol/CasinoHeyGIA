using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class CierreRuletaController(IMediator _mediator) : Controller
    {
        [HttpPost("/CierreRuleta")]
        public async Task<ActionResult<string>> CierreRuleta(
            [FromBody] CierreRuletaAux request,
            [FromHeader(Name = "Id_usuario")] string idUsuario = null
            )
        {
            CierreRuletaRequest request1 = new CierreRuletaRequest()
            {
                Id_Ruleta = request.Id_Ruleta,
                idUsuario = idUsuario
            };
            var command = new CierreRuletaCommand()
            {
                Request = request1
            };
            var response = await _mediator.Send(command);
            return this.Ok(response);
        }
    }
}
