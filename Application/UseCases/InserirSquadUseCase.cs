using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class InserirSquadUseCase : IInserirSquadUseCase
    {
        private readonly ISquadRepository _squadRepository;
        public InserirSquadUseCase(ISquadRepository squadRepository)
        {
            _squadRepository = squadRepository;
        }

        public string InserirSquad(string nomeSquad)
        {
            return _squadRepository.InserirSquad(nomeSquad);
        }
    }
}
