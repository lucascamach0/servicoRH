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
