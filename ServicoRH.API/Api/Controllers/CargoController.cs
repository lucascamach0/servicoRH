using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("cargo")]
    public class CargoController
    {
        private readonly RetornarListaDeCargosUseCase _retornarListaDeCargosUseCase;
        private readonly InserirCargoUseCase _inserirCargoUseCase;

        public CargoController()
        {
            _retornarListaDeCargosUseCase = new RetornarListaDeCargosUseCase();
            _inserirCargoUseCase = new InserirCargoUseCase();
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
