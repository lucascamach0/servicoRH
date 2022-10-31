using Moq;
using ServicoRH.API.Infra.Interface;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarListaDeCargosUseCaseTest
    {
        private readonly Mock<ICargoRepository> _repositoryMock = new Mock<ICargoRepository>();

        [Fact]
        public void RetornarListaDeCargosComSucesso()
        {
            //Arrage
            List<Cargo> listaDeCargos = new List<Cargo>();
            Cargo cargo = new Cargo();
            cargo.Nome = "Tester";
            listaDeCargos.Add(cargo);
            _repositoryMock.Setup(a => a.ObterTodosOsCargos()).Returns(listaDeCargos);

            RetornarListaDeCargosUseCase useCase = new RetornarListaDeCargosUseCase(_repositoryMock.Object);

            //Action
            var listaRetorno = useCase.ObterListaDeCargos();

            //Assert
            Assert.NotNull(listaRetorno);
            Assert.Single(listaRetorno);
        }
    }
}
