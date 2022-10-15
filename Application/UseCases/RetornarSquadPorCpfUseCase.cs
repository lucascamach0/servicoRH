using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class RetornarSquadPorCpfUseCase : IRetornarSquadPorCpfUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public RetornarSquadPorCpfUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public string BuscarSquadPorCpf(string cpf)
        {
            return _colaboradorRepository.BuscarSquadPorCpf(cpf);
        }
    }
}
