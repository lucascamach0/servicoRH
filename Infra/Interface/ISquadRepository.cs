using ServicoRH.Domain;
using ServicoRH.DTO;

namespace ServicoRH.Infra.Interface
{
    public interface ISquadRepository
    {
        List<Squad> ObterTodosAsSquads();
        string InserirSquad(string nomeSquad);
        string AlterarSquad(AlterarSquadDTO colaborador);
    }
}
