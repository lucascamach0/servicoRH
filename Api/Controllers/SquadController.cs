using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases;
using ServicoRH.DTO;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("squad")]
    public class SquadController
    {
        private readonly RetornarListaDeSquadsUseCase _retornarListaDeSquadsUseCase;
        public SquadController()
        {
            _retornarListaDeSquadsUseCase = new RetornarListaDeSquadsUseCase();
        }

        [HttpGet]
        [Route("BuscarListaDeSquads")]
        public List<SquadDTO> BuscarListaDeSquads()
        {
            return _retornarListaDeSquadsUseCase.ObterListaDeSquads();
        }

    }
}
