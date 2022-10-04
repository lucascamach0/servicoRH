using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.DTO;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("Colaborador")]
    public class ColaboradorController
    {
        private readonly RetornarSalarioPorCpfUseCase _retornarSalarioPorCpfUseCase;
        private readonly RetornarDadosDoColaboradorUseCase _retornarDadosDoColaboradorUseCase;
        private readonly RetornarCargoDoColaboradorUseCase _retornarCargoDoColaboradorUseCase;
        private readonly RetornarSquadPorCpfUseCase _retornarSquadPorCpfUseCase;
        private readonly RetonarListaDeColaboradoresPorSquadUseCase _retonarListaDeColaboradoresPorSquadUseCase;
        private readonly RetornarListaDeColaboradorPorSalarioUseCase _retornarlistaDeColaboradorPorSalarioUseCase;

        public ColaboradorController()
        {
            _retornarSalarioPorCpfUseCase = new RetornarSalarioPorCpfUseCase();
            _retornarDadosDoColaboradorUseCase = new RetornarDadosDoColaboradorUseCase();
            _retornarCargoDoColaboradorUseCase = new RetornarCargoDoColaboradorUseCase();
            _retornarSquadPorCpfUseCase = new RetornarSquadPorCpfUseCase();
            _retonarListaDeColaboradoresPorSquadUseCase = new RetonarListaDeColaboradoresPorSquadUseCase();
            _retornarlistaDeColaboradorPorSalarioUseCase = new RetornarListaDeColaboradorPorSalarioUseCase();
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
    }
}
