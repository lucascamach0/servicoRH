﻿using Microsoft.AspNetCore.Mvc;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;

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

        public ColaboradorController()
        {
            _retornarSalarioPorCpfUseCase = new RetornarSalarioPorCpfUseCase();
            _retornarDadosDoColaboradorUseCase = new RetornarDadosDoColaboradorUseCase();
            _retornarCargoDoColaboradorUseCase = new RetornarCargoDoColaboradorUseCase();
            _retornarSquadPorCpfUseCase = new RetornarSquadPorCpfUseCase();
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
    }
}
