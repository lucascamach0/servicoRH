using ServicoRH.API.Application.UseCases.Interfaces;
using ServicoRH.API.Infra.Interface;
using ServicoRH.Domain;

namespace ServicoRH.Application.UseCases
{
    public class RetornarListaDeCargosUseCase : IRetornarListaDeCargosUseCase
    {
        private readonly ICargoRepository _cargoRepository;
        public RetornarListaDeCargosUseCase(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public List<Cargo> ObterListaDeCargos()
        {
            List<Cargo> cargos = _cargoRepository.ObterTodosOsCargos();

            return cargos;
        }
    }
}
