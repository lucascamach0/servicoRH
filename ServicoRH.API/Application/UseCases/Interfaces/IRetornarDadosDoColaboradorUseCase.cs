using ServicoRH.Domain;

namespace ServicoRH.Application.UseCases.Interfaces
{
    public interface IRetornarDadosDoColaboradorUseCase
    {
        Colaborador ObterDadosDoColaborador(string cpf);
    }
}
