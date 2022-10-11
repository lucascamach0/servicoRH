using ServicoRH.DTO;

namespace ServicoRH.Application.UseCases.Interfaces
{
    public interface IRetonarListaDeColaboradoresPorSquadUseCase
    {
        List<ColaboradorDTO> ObterTodosOsDadosDoColaboradorPorSquad(string squad);
    }
}
