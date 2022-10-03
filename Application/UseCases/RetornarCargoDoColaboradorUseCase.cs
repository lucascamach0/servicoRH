using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarCargoDoColaboradorUseCase
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
