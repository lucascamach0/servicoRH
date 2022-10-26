using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class DeletarColaboradorUseCase : IDeletarColaboradorUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IRetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;

        public DeletarColaboradorUseCase(IColaboradorRepository colaboradorRepository,
            IRetornarDadosDoColaboradorUseCase retornarDadosDoColaboradorUseCase)
        {
            _colaboradorRepository = colaboradorRepository;
            _retornarDadosDoColaboradorUseCase = retornarDadosDoColaboradorUseCase;
        }
        public string ExcluirColaborador(string cpf)
        {
            Colaborador colaboradorResposta = new Colaborador();

            colaboradorResposta = _retornarDadosDoColaboradorUseCase.ObterDadosDoColaborador(cpf);

            if (colaboradorResposta.Cpf == null)
            {
                return "Usuário não encontrado";
            }
            return _colaboradorRepository.DeletarColaborador(cpf);
        }

    }
}
