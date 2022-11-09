namespace ServicoRH.API.Application.UseCases.Interfaces
{
    public interface IRetornarValorDeImpostoPagoUseCase
    {
        public double ObterValorDeImposto(string cpf);
    }
}
