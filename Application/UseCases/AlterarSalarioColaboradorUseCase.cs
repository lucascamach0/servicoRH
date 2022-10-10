using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class AlterarSalarioColaboradorUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        private readonly RetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;

        public AlterarSalarioColaboradorUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
            _retornarDadosDoColaboradorUseCase = new RetornarDadosDoColaboradorUseCase();
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
