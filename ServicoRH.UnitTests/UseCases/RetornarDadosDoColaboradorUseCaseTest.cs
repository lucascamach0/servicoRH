using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarDadosDoColaboradorUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();

        [Fact]
        public void RetornarDadosDoColaboradorComSucesso()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Cpf = "123";

            _repositoryMock.Setup(a => a.BuscarColaboradorPorCpf(It.IsAny<string>())).Returns(colaborador);

            RetornarDadosDoColaboradorUseCase useCase = new RetornarDadosDoColaboradorUseCase(_repositoryMock.Object);

            var response = useCase.ObterDadosDoColaborador("123");

            Assert.Equal("123", response.Cpf);
        }
    }
}
