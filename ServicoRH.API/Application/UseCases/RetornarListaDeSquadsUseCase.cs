using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class RetornarListaDeSquadsUseCase : IRetornarListaDeSquadsUseCase
    {
        private readonly ISquadRepository _squadRepository;

        public RetornarListaDeSquadsUseCase(ISquadRepository squadRepository)
        {
           _squadRepository = squadRepository;
        }

        public List<SquadDTO> ObterListaDeSquads()
        {

            List<Squad> squads = _squadRepository.ObterTodosAsSquads();
            List<SquadDTO> squadsDTO = new List<SquadDTO>();

            foreach (Squad squadAuxiliar in squads)
            {
                SquadDTO squadDTO = new SquadDTO();
                squadDTO.IdSquad = squadAuxiliar.IdSquad;
                squadDTO.Nome = squadAuxiliar.Nome;
                squadsDTO.Add(squadDTO);

            }
            return squadsDTO;
        }
    }
}
