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

        private Cargo ObterCargoQA()
        {
            List<Cargo> cargos = _cargoRepository.ObterTodosOsCargos();

            foreach (var cargoAuxilar in cargos)
            {
                if (cargoAuxilar.Nome.Equals("QA"))
                {
                    return cargoAuxilar;
                }
            }

            var cargo = cargos.Where(a => a.Nome.Equals("QA")).FirstOrDefault();
            var cargosABC = cargos.Where(a => a.Nome.Equals("Squad Leader") || a.Nome.Equals("QA"));

            return cargo;
        }
    }
}
