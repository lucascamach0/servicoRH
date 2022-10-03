using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarSquadPorCpfUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public RetornarSquadPorCpfUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }

        public string BuscarSquadPorCpf(string cpf)
        {
            return _colaboradorRepository.BuscarSquadPorCpf(cpf);
        }
    }
}
