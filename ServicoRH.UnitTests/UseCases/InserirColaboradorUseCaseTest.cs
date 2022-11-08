using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class InserirColaboradorUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();

        [Fact]
        public void InseirColaboradorComSucesso()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Cpf = "123";
            InserirColaboradorDTO inserirColaboradorDTO = new InserirColaboradorDTO();

            _repositoryMock.Setup(a => a.InserirColaborador(It.IsAny<InserirColaboradorDTO>())).Returns("123");

            InserirColaboradorUseCase useCase = new InserirColaboradorUseCase(_repositoryMock.Object);

            var response = useCase.InserirColaborador(inserirColaboradorDTO);

            Assert.NotNull(response);
            Assert.Equal("123", response);
        }
    }
}
