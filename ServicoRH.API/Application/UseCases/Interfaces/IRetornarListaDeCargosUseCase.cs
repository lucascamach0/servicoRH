using ServicoRH.Domain;

namespace ServicoRH.API.Application.UseCases.Interfaces
{
    public interface IRetornarListaDeCargosUseCase
    {
        public List<Cargo> ObterListaDeCargos();
    }
}
