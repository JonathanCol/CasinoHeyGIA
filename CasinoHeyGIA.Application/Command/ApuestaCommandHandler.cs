using CasinoHeyGIA.Application.Interfaces;
using CasinoHeyGIA.Application.Models;
using CasinoHeyGIA.Domain.Interfaces;
using MediatR;

namespace CasinoHeyGIA.Application.Command
{
    public class ApuestaCommandHandler(IUserRepository _userRepository, ICacheService _cacheService) : IRequestHandler<ApuestaCommand, ApuestaResponse>
    {
        public async Task<ApuestaResponse> Handle(ApuestaCommand request, CancellationToken cancellationToken)
        {
            ApuestaResponse response = new ApuestaResponse();
            var usuario = await _userRepository.GetUserAsync(int.Parse(request.Request.IdUsuario));

            if(usuario.FirstOrDefault().Saldo < request.Request.Apuesta)
            {
                response.response = "Saldo insuficiente para la apuesta";
            }
            else
            {
                response.response = "Apuesta realizada";
                await _cacheService.SetAsync($"{request.Request.Id_ruleta}-Apuesta",  );
            }
                //var ruleta = Random.Shared.Next(0, 36);

                //if (ruleta.Equals(request.Request.Numero))
                //{
                //    await _cacheService.SetAsync($"{request.Request.Id_ruleta}-Apuesta",  );
                //}
           return response;
        }
    }
}
