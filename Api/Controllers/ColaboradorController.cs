using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases;

namespace ServicoRH.Api.Controllers
{
    [ApiController]
    [Route("Colaborador")]
    public class ColaboradorController
    {
        private readonly RetornarSalarioPorCpfUseCase _retornarSalarioPorCpfUseCase;

        public ColaboradorController()
        {
            _retornarSalarioPorCpfUseCase = new RetornarSalarioPorCpfUseCase();
        }

        [HttpGet]
        [Route("BuscarSalarioPorCpf")]
        public double BuscarSalarioPorCpf(string cpf)
        {
            return _retornarSalarioPorCpfUseCase.obterSalarioPorCpf(cpf);
        }

    }
}
