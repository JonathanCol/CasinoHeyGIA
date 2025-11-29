using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class RuletaCierreController(IMediator _mediator) : Controller
    {
        [HttpPost("/Cierre")]
        public async Task<ActionResult<string>> Cierre(
            [FromBody] RuletaCierreAux request,
            [FromHeader(Name = "Id-Usuario")] string idUsuario = null
            )
        {
            if(string.IsNullOrEmpty(idUsuario))
            {
                throw new HttpRequestException("Autenticación fallida");
            }
            RuletaCierreRequest request1 = new RuletaCierreRequest()
            {   
                IdRuleta = request.IdRuleta,
                IdUsuario = idUsuario
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
