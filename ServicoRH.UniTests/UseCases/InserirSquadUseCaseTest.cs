using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class InserirSquadUseCaseTest
    {
        private readonly Mock<ISquadRepository> _repositoryMock = new Mock<ISquadRepository>();

        public InserirSquadUseCaseTest()
        {
        }

        [Fact]
        public void InserirCargoComSucesso()
        {

            //Arrange
            _repositoryMock.Setup(a => a.InserirSquad(It.IsAny<string>())).Returns("Squad inserida com sucesso!");
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
