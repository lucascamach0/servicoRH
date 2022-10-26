using ServicoRH.Domain;
using ServicoRH.DTO;

namespace ServicoRH.Infra.Interface
{
    public interface IColaboradorRepository
    {
        Colaborador BuscarColaboradorPorCpf(string cpf);
        string BuscarCargoDoColaborador(string cpf);
        string BuscarSquadPorCpf(string cpf);
        List<Colaborador> BucarTodosOsColaboradorPorSquad(string squad);
        List<Colaborador> BuscarColaboradorPorSalario(double salario);
        string InserirColaborador(InserirColaboradorDTO colaborador);
        string AlterarSalarioColaborador(AlterarSalarioColaboradorDTO colaborador);
        string DeletarColaborador(string cpf);
    }
}
