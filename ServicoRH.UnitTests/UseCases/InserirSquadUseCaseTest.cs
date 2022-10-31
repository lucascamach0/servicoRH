using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class InserirSquadUseCaseTest
    {
        // criação do mock
        private readonly Mock<ISquadRepository> _repositoryMock = new Mock<ISquadRepository>();

        public InserirSquadUseCaseTest()
        {
        }

        [Fact]
        public void InserirSquadComSucesso()
        {

            //Arrange
            //preparação para executar o teste (simulando o método do repositório)
            _repositoryMock.Setup(a => a.InserirSquad(It.IsAny<string>())).Returns("Squad inserida com sucesso!");
            //criando o serviço e passando a dependência(mock)
            IInserirSquadUseCase service = new InserirSquadUseCase(_repositoryMock.Object);
            string parametro = "SquadTest";

            //Action

            string response = service.InserirSquad(parametro);

            //Assert

            string expect = "Squad inserida com sucesso!";

            Assert.Equal(expect, response);
        }
    }
}
