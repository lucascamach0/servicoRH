using ServicoRH.Domain;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class DeletarColaboradorUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        private readonly RetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;

        public DeletarColaboradorUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
            _retornarDadosDoColaboradorUseCase = new RetornarDadosDoColaboradorUseCase();
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
