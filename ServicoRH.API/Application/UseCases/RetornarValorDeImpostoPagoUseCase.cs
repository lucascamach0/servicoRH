using ServicoRH.API.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;

namespace ServicoRH.API.Application.UseCases
{
    public class RetornarValorDeImpostoPagoUseCase : IRetornarValorDeImpostoPagoUseCase
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        public RetornarValorDeImpostoPagoUseCase(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }
        public double ObterValorDeImposto(string cpf)
        {
            Colaborador colaborador = _colaboradorRepository.BuscarColaboradorPorCpf(cpf);

            double valorSalario = colaborador.Salario;
            double valorPago = 0;

            if (valorSalario <= 1903.98)
            {
                valorPago = 0;
            }

            else if (valorSalario >= 1903.99 && valorSalario <= 2826.65)
            {
                valorPago = (valorSalario * 0.075);
            }

            else if (valorSalario >= 2826.66 && valorSalario <= 3751.05)
            {
                valorPago = (valorSalario * 0.15);
            }

            else if (valorSalario >= 3751.06 && valorSalario <= 4664.68)
            {
                valorPago = (valorSalario * 0.225);
            }

            else if (valorSalario >= 4664.68)
            {
                valorPago = (valorSalario * 0.275);
            }
            return valorPago;
        }
    }
}
