using ServicoRH.API.Application.UseCases.Interfaces;
using ServicoRH.API.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class InserirCargoUseCase : IInserirCargoUseCase
    {
        private readonly ICargoRepository _cargoRepository;
        public InserirCargoUseCase(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        public string InserirCargo(string nomeCargo)
        {
            return _cargoRepository.InserirCargo(nomeCargo);
        }
    }
}
