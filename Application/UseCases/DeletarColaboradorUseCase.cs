using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class DeletarColaboradorUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public DeletarColaboradorUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }
        public string ExcluirColaborador(string cpf)
        {
            return _colaboradorRepository.DeletarColaborador(cpf);
        }

    }
}
