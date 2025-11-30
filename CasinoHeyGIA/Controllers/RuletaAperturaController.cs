using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class RuletaAperturaController(IMediator _mediator) : Controller
    {
        [HttpPost("/Apertura")]
        public async Task<ActionResult<string>> Apertura([FromBody] RuletaAperturaRequest request)
        {
            var command = new RuletaAperturaCommand() 
            {
                Request = request
            };
            var response = await _mediator.Send(command);
            return this.Ok(response);
        }
    }
}
