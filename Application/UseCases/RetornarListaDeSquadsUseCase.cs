using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarListaDeSquadsUseCase
    {
        private readonly SquadRepository _squadRepository;
        public RetornarListaDeSquadsUseCase()
        {
            _squadRepository = new SquadRepository();
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
