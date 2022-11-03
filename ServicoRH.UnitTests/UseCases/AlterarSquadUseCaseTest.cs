using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class AlterarSquadUseCaseTest
    {
        private readonly Mock<ISquadRepository> _repositoryMock = new Mock<ISquadRepository>();
        private readonly Mock<IRetornarDadosDoColaboradorUseCase> _retornarDadosDoColaboradorUseCaseMock = new Mock<IRetornarDadosDoColaboradorUseCase>();
        private readonly Mock<IRetornarListaDeSquadsUseCase> _retornarListaDeSquadsUseCaseMock = new Mock<IRetornarListaDeSquadsUseCase>();

        [Fact]
        public void AlterarSquadComSucesso()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Cpf = "123";
            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);
            List<SquadDTO> listaSquadDTO = new List<SquadDTO>();
            SquadDTO squadDTO = new SquadDTO();
            squadDTO.Nome = "E2A";
            listaSquadDTO.Add(squadDTO);
            _retornarListaDeSquadsUseCaseMock.Setup(a => a.ObterListaDeSquads()).Returns(listaSquadDTO);
            _repositoryMock.Setup(a => a.AlterarSquad(It.IsAny<AlterarSquadDTO>())).Returns("Alteração realizada com sucesso");

            AlterarSquadUseCase useCase = new AlterarSquadUseCase(_repositoryMock.Object, _retornarDadosDoColaboradorUseCaseMock.Object, _retornarListaDeSquadsUseCaseMock.Object);

            var response = useCase.AlterarSquad(new AlterarSquadDTO());

            Assert.Equal("Alteração realizada com sucesso", response);
        }

        [Fact]
        public void AlterarSquadComSquadNaoEncontrada()
        {

        }

        [Fact]
        public void ColaboradorNaoEncontrada()
        {

        }
    }
}
