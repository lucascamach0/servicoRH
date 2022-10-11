using ServicoRH.DTO;

namespace ServicoRH.Application.UseCases.Interfaces
{
    public interface IInserirColaboradorUseCase
    {
        string InserirColaborador(InserirColaboradorDTO colaborador);
    }
}
