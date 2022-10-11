using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.DTO;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("squad")]
    public class SquadController
    {
        private readonly IRetornarListaDeSquadsUseCase _retornarListaDeSquadsUseCase;
        private readonly IInserirSquadUseCase _inserirSquadUseCase;

        public SquadController(IRetornarListaDeSquadsUseCase retornarListaDeSquadsUseCase,
                                IInserirSquadUseCase inserirSquadUseCase)
        {
            _retornarListaDeSquadsUseCase = retornarListaDeSquadsUseCase;
            _inserirSquadUseCase = inserirSquadUseCase;

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
