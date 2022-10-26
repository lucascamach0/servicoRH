using ServicoRH.DTO;

namespace ServicoRH.Application.UseCases.Interfaces
{
    public interface IRetornarListaDeSquadsUseCase
    {
        List<SquadDTO> ObterListaDeSquads();
    }
}
