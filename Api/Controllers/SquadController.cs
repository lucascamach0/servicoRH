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
        private readonly InserirSquadUseCase _inserirSquadUseCase;
        public SquadController()
        {
            _retornarListaDeSquadsUseCase = new RetornarListaDeSquadsUseCase();
            _inserirSquadUseCase = new InserirSquadUseCase();
        }

        [HttpGet]
        [Route("BuscarListaDeSquads")]
        public List<SquadDTO> BuscarListaDeSquads()
        {
            return _retornarListaDeSquadsUseCase.ObterListaDeSquads();
        }

        [HttpPost]
        [Route("InserirSquad")]
        public string InserirSquad([FromBody] string nomeSquad)
        {
            return _inserirSquadUseCase.InserirSquad(nomeSquad);
        }

    }
}
