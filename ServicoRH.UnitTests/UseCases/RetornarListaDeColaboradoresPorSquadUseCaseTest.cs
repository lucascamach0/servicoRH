using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarListaDeColaboradoresPorSquadUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();

        [Fact]
        public void RetornarListaDeColaboradoresPorSquadComSucesso()
        {
            //Arrage
            List<Colaborador> listaDeColaborador = new List<Colaborador>();
            Colaborador colaborador = new Colaborador();
            colaborador.Nome = "João";
            listaDeColaborador.Add(colaborador);
            // It.IsAny<string simula o parametro
            _repositoryMock.Setup(a => a.BucarTodosOsColaboradorPorSquad(It.IsAny<string>())).Returns(listaDeColaborador);

            RetornarListaDeColaboradoresPorSquadUseCase useCase = new RetornarListaDeColaboradoresPorSquadUseCase(_repositoryMock.Object);

            //Action
            var listaRetorno = useCase.ObterTodosOsDadosDoColaboradorPorSquad("squadTest");

            //Assert
            Assert.NotNull(listaRetorno);
            Assert.Single(listaRetorno);
            Assert.True(listaRetorno.Select(a => a.Nome.Equals("João")).FirstOrDefault());
        }
    }
}
