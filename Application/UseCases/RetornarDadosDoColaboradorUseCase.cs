using ServicoRH.Domain;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarDadosDoColaboradorUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public RetornarDadosDoColaboradorUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }

        public Colaborador ObterDadosDoColaborador(string cpf)
        {
            Colaborador colaborador = _colaboradorRepository.BuscarColaboradorPorCpf(cpf);

            return colaborador;
        }
    }
}
