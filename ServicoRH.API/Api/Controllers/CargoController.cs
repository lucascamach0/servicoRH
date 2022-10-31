using Microsoft.AspNetCore.Mvc;
using ServicoRH.API.Application.UseCases.Interfaces;
using ServicoRH.Domain;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("cargo")]
    public class CargoController
    {
        private readonly IRetornarListaDeCargosUseCase _retornarListaDeCargosUseCase;
        private readonly IInserirCargoUseCase _inserirCargoUseCase;

        public CargoController(IInserirCargoUseCase inserirCargoUseCase, IRetornarListaDeCargosUseCase retornarListaDeCargos)
        {
            _retornarListaDeCargosUseCase = retornarListaDeCargos;
            _inserirCargoUseCase = inserirCargoUseCase;
        }

        [HttpGet]
        [Route("BuscarListaDeCargos")]
        public List<Cargo> BuscarListaDeCargos()
        {
            return _retornarListaDeCargosUseCase.ObterListaDeCargos();
        }

        [HttpPost]
        [Route("InserirCargo")]
        public string InserirCargo([FromBody] string nomeCargo)
        {
            return _inserirCargoUseCase.InserirCargo(nomeCargo);
        }
    }
}
