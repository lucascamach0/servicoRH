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

        public CargoController()
        {
            _retornarListaDeCargosUseCase = new RetornarListaDeCargosUseCase();
        }

        [HttpGet]
        [Route("BuscarListaDeCargos")]
        public List<Cargo> BuscarListaDeCargos()
        {
            return _retornarListaDeCargosUseCase.ObterListaDeCargos();
        }
    }
}
