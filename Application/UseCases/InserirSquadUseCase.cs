using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class InserirSquadUseCase
    {
        private readonly SquadRepository _squadRepository;
        public InserirSquadUseCase()
        {
            _squadRepository = new SquadRepository();
        }

        public string InserirSquad(string nomeSquad)
        {
            return _squadRepository.InserirSquad(nomeSquad);
        }
    }
}
