using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class CierreRuletaController(IMediator _mediator) : Controller
    {
        [HttpPost("/CierreRuleta")]
        public async Task<ActionResult<string>> CierreRuleta([FromBody] CierreRuletaRequest idRuleta)
        {
            var request = new CierreRuletaCommand()
            {
                Request = idRuleta
            };
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
