﻿using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.DTO;
using ServicoRH.Infra;

namespace ServicoRH.Application.UseCases
{
    public class InserirColaboradorUseCase : IInserirColaboradorUseCase
    {
        private readonly ColaboradorRepository _colaboradorRepository;
        public InserirColaboradorUseCase()
        {
            _colaboradorRepository = new ColaboradorRepository();
        }

        public string InserirColaborador(InserirColaboradorDTO colaborador)
        {
            return _colaboradorRepository.InserirColaborador(colaborador);
        }
    }
}
