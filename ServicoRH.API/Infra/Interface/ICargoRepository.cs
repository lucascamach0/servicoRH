using ServicoRH.Domain;

namespace ServicoRH.API.Infra.Interface
{
    public interface ICargoRepository
    {
        public List<Cargo> ObterTodosOsCargos();

        public string InserirCargo(string nomeCargo);
    }
}
