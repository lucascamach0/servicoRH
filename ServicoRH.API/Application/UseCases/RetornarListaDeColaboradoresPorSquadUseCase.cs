using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;

namespace ServicoRH.Application.UseCases
{
    public class RetornarListaDeColaboradoresPorSquadUseCase : IRetonarListaDeColaboradoresPorSquadUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public RetornarListaDeColaboradoresPorSquadUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public List<ColaboradorDTO> ObterTodosOsDadosDoColaboradorPorSquad(string squad)
        {
            List<Colaborador> colaboradores = _colaboradorRepository.BucarTodosOsColaboradorPorSquad(squad);
            List<ColaboradorDTO> listaColaboradoresDto = new List<ColaboradorDTO>();
            foreach (var valorAuxiliar in colaboradores)
            {
                ColaboradorDTO colaboradorDTO = new ColaboradorDTO();
                colaboradorDTO.Nome = valorAuxiliar.Nome;
                colaboradorDTO.Cpf = valorAuxiliar.Cpf;
                colaboradorDTO.Salario = valorAuxiliar.Salario;
                colaboradorDTO.DataNascimento = valorAuxiliar.DataNascimento;
                colaboradorDTO.DataAdmissao = valorAuxiliar.DataAdmissao;
                colaboradorDTO.Cargo = valorAuxiliar.Cargo;
                colaboradorDTO.Squad = valorAuxiliar.Squad;
                listaColaboradoresDto.Add(colaboradorDTO);
            }
            return listaColaboradoresDto;
        }
    }
}
