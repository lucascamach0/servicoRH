using ServicoRH.Domain;

namespace ServicoRH.Application.UseCases.Interfaces
{
    public interface IRetornarListaDeColaboradorPorSalarioUseCase
    {
        List<SalarioDTO> ObterListaDeColaboradorPorSalario(double salario);
    }
}
