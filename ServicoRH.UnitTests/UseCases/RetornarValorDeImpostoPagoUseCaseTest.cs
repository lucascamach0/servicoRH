using Moq;
using ServicoRH.API.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarValorDeImpostoPagoUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();

        /*[Fact]
        public void RetornarSucessoImpostoIsento()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = 1500;

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarValorDeImpostoPagoUseCase useCase = new RetornarValorDeImpostoPagoUseCase(_repositoryMock.Object);

            double response = useCase.ObterValorDeImposto("123");

            Assert.Equal(0, response);
        }
        [Fact]
        public void RetornarSucessoImpostoSeteEMeioPorcento()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = 2500;

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarValorDeImpostoPagoUseCase useCase = new RetornarValorDeImpostoPagoUseCase(_repositoryMock.Object);

            double response = useCase.ObterValorDeImposto("123");

            Assert.Equal(187.5, response);
        }
        [Fact]
        public void RetornarSucessoImpostoQuinzePorcento()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = 3500;

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarValorDeImpostoPagoUseCase useCase = new RetornarValorDeImpostoPagoUseCase(_repositoryMock.Object);

            double response = useCase.ObterValorDeImposto("123");

            Assert.Equal(3500 * 0.15, response);
        }
        [Fact]
        public void RetornarSucessoImpostoVinteDoisEMeioPorcento()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = 4500;

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarValorDeImpostoPagoUseCase useCase = new RetornarValorDeImpostoPagoUseCase(_repositoryMock.Object);

            double response = useCase.ObterValorDeImposto("123");

            Assert.Equal(colaborador.Salario * 0.225, response);
        }
        [Fact]
        public void RetornarSucessoImpostoVinteSeteEMeioPorcento()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = 5500;

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarValorDeImpostoPagoUseCase useCase = new RetornarValorDeImpostoPagoUseCase(_repositoryMock.Object);

            double response = useCase.ObterValorDeImposto("123");

            Assert.Equal(colaborador.Salario * 0.275, response);
        }*/
        [Theory]
        [InlineData(1500, 0)]
        [InlineData(2500, 0.075)]
        [InlineData(3500, 0.15)]
        [InlineData(4500, 0.225)]
        [InlineData(5500, 0.275)]
        public void RetornarSucessoImpostoDeRenda(double salario, double porcentagem)
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Salario = salario;

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarValorDeImpostoPagoUseCase useCase = new RetornarValorDeImpostoPagoUseCase(_repositoryMock.Object);

            double response = useCase.ObterValorDeImposto("123");

            Assert.Equal(colaborador.Salario * porcentagem, response);
        }
    }
}
