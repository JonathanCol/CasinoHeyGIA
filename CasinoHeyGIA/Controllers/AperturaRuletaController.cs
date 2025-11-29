using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class AperturaRuletaController(IMediator _mediator) : Controller
    {
        [HttpPost("/AperturaRuleta")]
        public async Task<ActionResult<string>> CreaRuleta([FromBody] AperturaRuletaRequest id)
        {
            var request = new AperturaRuletaCommand() 
            {
                Request = id
            };
            var response = await _mediator.Send(request);
            return response.Estado;
        }
    }
}
