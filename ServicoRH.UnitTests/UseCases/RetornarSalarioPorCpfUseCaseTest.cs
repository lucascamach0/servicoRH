using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarSalarioPorCpfUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();

        [Fact]
        public void RetornarSalarioPorCpfComSucesso()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = 1000;
            //setup é o metodo de simulação do mock
            // expressão lâmbida que vai simular o método do repository
            // returns que vai fazer a simulação do retorno e passa o retorno que eu quero simular
            // It.IsAny<string simula o parametro
            //instancia do usecase real
            //object é um atributo que fala que é um mock
            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);
            RetornarSalarioPorCpfUseCase useCase = new RetornarSalarioPorCpfUseCase(_repositoryMock.Object);

            var retorno = useCase.obterSalarioPorCpf("teste");

            Assert.Equal(1000, retorno);

        }
    }
}
