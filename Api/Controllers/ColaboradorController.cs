using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("Colaborador")]
    public class ColaboradorController
    {
        private readonly IRetornarSalarioPorCpfUseCase _retornarSalarioPorCpfUseCase;
        private readonly IRetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;
        private readonly IRetornarCargoDoColaboradorUseCase _retornarCargoDoColaboradorUseCase;
        private readonly IRetornarSquadPorCpfUseCase _retornarSquadPorCpfUseCase;
        private readonly IRetonarListaDeColaboradoresPorSquadUseCase _retonarListaDeColaboradoresPorSquadUseCase;
        private readonly IRetornarListaDeColaboradorPorSalarioUseCase _retornarlistaDeColaboradorPorSalarioUseCase;
        private readonly IInserirColaboradorUseCase _inserirColaboradorUseCase;
        private readonly IAlterarSalarioColaboradorUseCase _alterarSalarioColaboradorUseCase;
        private readonly IDeletarColaboradorUseCase _deletarColaboradorUseCase;

        public ColaboradorController(IDeletarColaboradorUseCase deletarColaboradorUseCase,
            IRetornarDadosDoColaboradorUseCase retornarDadosDoColaboradorUseCase,
            IRetornarCargoDoColaboradorUseCase retornarCargoDoColaboradorUseCase,
            IRetornarSquadPorCpfUseCase retornarSquadPorCpfUseCase,
            IRetonarListaDeColaboradoresPorSquadUseCase retonarListaDeColaboradoresPorSquadUseCase,
            IRetornarListaDeColaboradorPorSalarioUseCase retornarListaDeColaboradorPorSalarioUseCase,
            IInserirColaboradorUseCase inserirColaboradorUseCase,
            IAlterarSalarioColaboradorUseCase alterarSalarioColaboradorUseCase,
            IRetornarSalarioPorCpfUseCase retornarSalarioPorCpfUseCase)
        {
            _retornarSalarioPorCpfUseCase = retornarSalarioPorCpfUseCase;
            _retornarDadosDoColaboradorUseCase = retornarDadosDoColaboradorUseCase;
            _retornarCargoDoColaboradorUseCase = retornarCargoDoColaboradorUseCase;
            _retornarSquadPorCpfUseCase = retornarSquadPorCpfUseCase;
            _retonarListaDeColaboradoresPorSquadUseCase = retonarListaDeColaboradoresPorSquadUseCase;
            _retornarlistaDeColaboradorPorSalarioUseCase = retornarListaDeColaboradorPorSalarioUseCase;
            _inserirColaboradorUseCase = inserirColaboradorUseCase;
            _alterarSalarioColaboradorUseCase = alterarSalarioColaboradorUseCase;
            _deletarColaboradorUseCase = deletarColaboradorUseCase;
        }

        [HttpGet]
        [Route("BuscarSalarioPorCpf")]
        public double BuscarSalarioPorCpf(string cpf)
        {
            return _retornarSalarioPorCpfUseCase.obterSalarioPorCpf(cpf);
        }

        [HttpGet]
        [Route("BuscarDadosColaborador")]
        public Colaborador BuscarDadosColaborador(string cpf)
        {
            return _retornarDadosDoColaboradorUseCase.ObterDadosDoColaborador(cpf);
        }

        [HttpGet]
        [Route("BuscarCargoColaborador")]
        public string BuscarCargoColaborador(string cpf)
        {
            //implementar dever de casa
            return _retornarCargoDoColaboradorUseCase.BuscarCargoDoColaborador(cpf);
        }

        [HttpGet]
        [Route("BuscarSquadPorCPF")]
        public string BuscarSquadColaborador(string cpf)
        {
            return _retornarSquadPorCpfUseCase.BuscarSquadPorCpf(cpf);
        }

        [HttpGet]
        [Route("BuscarColaboradorPorSquad")]
        public List<ColaboradorDTO> BuscarlistaDeColaboradores(string squad)
        {
            return _retonarListaDeColaboradoresPorSquadUseCase.ObterTodosOsDadosDoColaboradorPorSquad(squad);
        }

        [HttpGet]
        [Route("BuscarColaboradorPorSalario")]
        public List<SalarioDTO> BuscarlistaDeColaboradores(double salario)
        {
            return _retornarlistaDeColaboradorPorSalarioUseCase.ObterListaDeColaboradorPorSalario(salario);
        }

        [HttpPost]
        [Route("InserirColaborador")]
        public string InserirColaborador([FromBody] InserirColaboradorDTO colaborador)
        {
            return _inserirColaboradorUseCase.InserirColaborador(colaborador);
        }

        [HttpPost]
        [Route("AlterarSalarioColaborador")]
        public string AlterarSalarioColaborador([FromBody] AlterarSalarioColaboradorDTO colaborador)
        {
            return _alterarSalarioColaboradorUseCase.AlterarSalario(colaborador);
        }

        [HttpPost]
        [Route("DeletarColaborador")]
        public string DeletarColaborador([FromBody] string cpf)
        {
            return _deletarColaboradorUseCase.ExcluirColaborador(cpf);
        }
    }
}
