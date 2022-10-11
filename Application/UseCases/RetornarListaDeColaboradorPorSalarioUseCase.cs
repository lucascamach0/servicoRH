using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class RetornarListaDeColaboradorPorSalarioUseCase : IRetornarListaDeColaboradorPorSalarioUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public RetornarListaDeColaboradorPorSalarioUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }

        public List<SalarioDTO> ObterListaDeColaboradorPorSalario(double salario)
        {
            List<Colaborador> colaboradores = _colaboradorRepository.BuscarColaboradorPorSalario(salario);
            List<SalarioDTO> listaColaboradoresDto = new List<SalarioDTO>();
            foreach (var valorAuxiliar in colaboradores)
            {
                SalarioDTO salarioDTO = new SalarioDTO();
                salarioDTO.Nome = valorAuxiliar.Nome;
                salarioDTO.Salario = valorAuxiliar.Salario;
                salarioDTO.Cargo = valorAuxiliar.Cargo;

                listaColaboradoresDto.Add(salarioDTO);
            }
            return listaColaboradoresDto;
        }
    }
}
