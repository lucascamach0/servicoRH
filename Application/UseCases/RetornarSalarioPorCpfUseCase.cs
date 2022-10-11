using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarSalarioPorCpfUseCase : IRetornarSalarioPorCpfUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public RetornarSalarioPorCpfUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }
        public double obterSalarioPorCpf(string cpf)
        {
            Colaborador colaborador = _colaboradorRepository.BuscarColaboradorPorCpf(cpf);

            return colaborador.Salario;
        }
    }
}
