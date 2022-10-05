using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class InserirCargoUseCase
    {
        private readonly CargoRepository _cargoRepository;
        public InserirCargoUseCase()
        {
            _cargoRepository = new CargoRepository();
        }

        public string InserirCargo(string nomeCargo)
        {
            return _cargoRepository.InserirCargo(nomeCargo);
        }
    }
}
