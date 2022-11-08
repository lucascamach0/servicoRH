using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarCargoDoColaboradorUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();

        [Fact]
        public void RetornarCargoDoColaboradorComSucesso()
        {

            _repositoryMock.Setup(a => a.BuscarCargoDoColaborador(It.IsAny<string>())).Returns("Programador");

            RetornarCargoDoColaboradorUseCase useCase = new RetornarCargoDoColaboradorUseCase(_repositoryMock.Object);

            var response = useCase.BuscarCargoDoColaborador("123");

            Assert.Equal("Programador", response);
        }
    }
}
