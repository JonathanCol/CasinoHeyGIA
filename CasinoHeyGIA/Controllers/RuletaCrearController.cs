using CasinoHeyGIA.Application.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CasinoHeyGIA.Controllers
{
    public class RuletaCrearController(IMediator _mediator) : Controller
    {
        [HttpGet("/CrearRuleta")]
        public async Task<ActionResult<string>> CreaRuleta()
        {
            var request = new RuletaCrearCommand();
            var response = await _mediator.Send(request);
            return response.ToString();
        }
    }
}
