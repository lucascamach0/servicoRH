using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarCargoDoColaboradorUseCase : IRetornarCargoDoColaboradorUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public RetornarCargoDoColaboradorUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }

        public string BuscarCargoDoColaborador(string cpf)
        {
            //implementar dever de casa

            return _colaboradorRepository.BuscarCargoDoColaborador(cpf);
        }
    }
}
