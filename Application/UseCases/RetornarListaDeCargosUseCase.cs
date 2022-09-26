using ServicoRH.Domain;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarListaDeCargosUseCase
    {
        private readonly CargoRepository _cargoRepository;
        public RetornarListaDeCargosUseCase()
        {
            _cargoRepository = new CargoRepository();
        }

        public List<Cargo> ObterListaDeCargos()
        {
            List<Cargo> cargos = _cargoRepository.ObterTodosOsCargos();
            return cargos;
        }
    }
}
