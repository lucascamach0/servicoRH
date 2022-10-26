using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class RetornarSalarioPorCpfUseCase : IRetornarSalarioPorCpfUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public RetornarSalarioPorCpfUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public double obterSalarioPorCpf(string cpf)
        {
            Colaborador colaborador = _colaboradorRepository.BuscarColaboradorPorCpf(cpf);

            return colaborador.Salario;
        }
    }
}
