using Moq;
using ServicoRH.API.Infra.Interface;
using ServicoRH.Application.UseCases;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class InserirCargoUseCaseTest
    {
        private readonly Mock<ICargoRepository> _repositoryMock = new Mock<ICargoRepository>();

        [Fact]
        public void InserirCargoComSucesso()
        {
            //Arrage
            //It.IsAny é a simulação do parâmetro 
            //returns é a simulação do retorno do método
            _repositoryMock.Setup(a => a.InserirCargo(It.IsAny<string>())).Returns("Cargo inserido com sucesso!");

            var useCase = new InserirCargoUseCase(_repositoryMock.Object);

            //Action
            var response = useCase.InserirCargo("Cargo teste");

            //Assert
            var expect = "Cargo inserido com sucesso!";
            Assert.Equal(expect, response);
        }
    }
}
