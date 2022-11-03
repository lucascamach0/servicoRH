using Moq;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class AlterarSquadUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();
        private readonly Mock<IRetornarDadosDoColaboradorUseCase> _retornarDadosDoColaboradorUseCaseMock = new Mock<IRetornarDadosDoColaboradorUseCase>();
        private readonly Mock<IRetornarListaDeSquadsUseCase> _retornarListaDeSquadsUseCasetest = new Mock<IRetornarListaDeSquadsUseCase>();

        [Fact]
        public void AlterarSquadComSucesso()
        {

        }

        [Fact]
        public void AlterarSquadComSquadNaoEncontrada()
        {

        }
    }
}
