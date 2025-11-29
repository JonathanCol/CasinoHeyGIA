using CasinoHeyGIA.Application.Command;
using CasinoHeyGIA.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class RuletaAperturaController(IMediator _mediator) : Controller
    {
        [HttpPost("/Apertura")]
        public async Task<ActionResult<string>> Apertura([FromBody] RuletaAperturaRequest id)
        {
            var request = new RuletaAperturaCommand() 
            {
                Request = id
            };
            var response = await _mediator.Send(request);
            return this.Ok(response);
        }
    }
}
