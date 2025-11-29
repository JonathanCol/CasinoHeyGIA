using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class CierreRuletaController : Controller
    {
        [HttpPost("/CierreRuleta")]
        public async Task<ActionResult<string>> CrearRuleta([FromBody] AperturaRuletaRequest id)
        {
            var request = new AperturaRuletaCommand()
            {
                Request = id
            };
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
