using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class AlterarSalarioColaboradorUseCase : IAlterarSalarioColaboradorUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IRetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;

        public AlterarSalarioColaboradorUseCase(IColaboradorRepository colaboradorRepository,
            IRetornarDadosDoColaboradorUseCase retornarDadosDoColaboradorUseCase)
        {
            _colaboradorRepository = colaboradorRepository;
            _retornarDadosDoColaboradorUseCase = retornarDadosDoColaboradorUseCase;
        }

        public string AlterarSalario(AlterarSalarioColaboradorDTO colaborador)
        {
            Colaborador colaboradorResposta = new Colaborador();

            colaboradorResposta = _retornarDadosDoColaboradorUseCase.ObterDadosDoColaborador(colaborador.Cpf);

            if (colaboradorResposta.Cpf == null)
            {
                return "Usuário não encontrado";
            }

            return _colaboradorRepository.AlterarSalarioColaborador(colaborador);
        }
    }
}
