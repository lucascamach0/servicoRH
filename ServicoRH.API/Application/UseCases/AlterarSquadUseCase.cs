using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class AlterarSquadUseCase : IAlterarSquadUseCase
    {
        private readonly ISquadRepository _squadRepository;
        private readonly IRetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;
        private readonly IRetornarListaDeSquadsUseCase _retornarListaDeSquadsUseCase;


        public AlterarSquadUseCase(ISquadRepository squadRepository,
            IRetornarDadosDoColaboradorUseCase retornarDadosDoColaboradorUseCase,
            IRetornarListaDeSquadsUseCase retornarListaDeSquadsUseCase)
        {
            _squadRepository = squadRepository;
            _retornarDadosDoColaboradorUseCase = retornarDadosDoColaboradorUseCase;
            _retornarListaDeSquadsUseCase = retornarListaDeSquadsUseCase;
        }

        public string AlterarSquad(AlterarSquadDTO colaborador)
        {
            Colaborador colaboradorResposta = new Colaborador();

            colaboradorResposta = _retornarDadosDoColaboradorUseCase.ObterDadosDoColaborador(colaborador.Cpf);

            if (colaboradorResposta.Cpf == null)
            {
                return "Colaborador não encontrado";
            }

            List<SquadDTO> listaSquads = _retornarListaDeSquadsUseCase.ObterListaDeSquads();

            SquadDTO? squad = listaSquads.Where(a => a.IdSquad == colaborador.IdSquad).FirstOrDefault();

            if (squad == null)
            {
                return "Squad não encontrada";
            }

            return _squadRepository.AlterarSquad(colaborador);
        }

    }
}
