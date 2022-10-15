using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class RetornarDadosDoColaboradorUseCase : IRetornarDadosDoColaboradorUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public RetornarDadosDoColaboradorUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public Colaborador ObterDadosDoColaborador(string cpf)
        {
            Colaborador colaborador = _colaboradorRepository.BuscarColaboradorPorCpf(cpf);

            return colaborador;
        }
    }
}
