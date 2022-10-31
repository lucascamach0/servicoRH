using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class RetornarListaDeSquadsUseCaseTest
    {
        private readonly Mock<ISquadRepository> _repositoryMock = new Mock<ISquadRepository>();

        [Fact]
        public void RetornarListaDeSquadsComSucesso()
        {
            //Arrage
            List<Squad> ListaDeSquads = new List<Squad>();
            Squad squad = new Squad();
            squad.Nome = "Unificar";
            ListaDeSquads.Add(squad);
            //setup é o metodo de simulação do mock
            // expressão lâmbida que vai simular o método do repository
            // returns que vai fazer a simulação do retorno e passa o retorno que eu quero simular
            _repositoryMock.Setup(a => a.ObterTodosAsSquads()).Returns(ListaDeSquads);
            //instancia do usecase real
            //object é um atributo que fala que é um mock
            RetornarListaDeSquadsUseCase useCase = new RetornarListaDeSquadsUseCase(_repositoryMock.Object);

            //Action
            var listaRetorno = useCase.ObterListaDeSquads();

            //Assert
            Assert.NotNull(listaRetorno);
            Assert.Single(listaRetorno);
        }

    }
}
