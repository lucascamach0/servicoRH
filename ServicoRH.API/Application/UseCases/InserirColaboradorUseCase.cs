using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class InserirColaboradorUseCase : IInserirColaboradorUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public InserirColaboradorUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public string InserirColaborador(InserirColaboradorDTO colaborador)
        {
            return _colaboradorRepository.InserirColaborador(colaborador);
        }
    }
}
