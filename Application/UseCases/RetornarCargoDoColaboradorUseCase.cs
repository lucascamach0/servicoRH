using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class RetornarCargoDoColaboradorUseCase : IRetornarCargoDoColaboradorUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public RetornarCargoDoColaboradorUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public string BuscarCargoDoColaborador(string cpf)
        {
            //implementar dever de casa

            return _colaboradorRepository.BuscarCargoDoColaborador(cpf);
        }
    }
}
