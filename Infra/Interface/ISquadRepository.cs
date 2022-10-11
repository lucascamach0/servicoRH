using ServicoRH.Domain;

namespace ServicoRH.Infra.Interface
{
    public interface ISquadRepository
    {
        List<Squad> ObterTodosAsSquads();
        string InserirSquad(string nomeSquad);
    }
}
