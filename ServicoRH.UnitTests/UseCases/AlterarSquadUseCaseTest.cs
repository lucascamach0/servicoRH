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
        public void ColaboradorNaoEncontrado()
        {
            Colaborador colaborador = new Colaborador();

            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);
            _repositoryMock.Setup(a => a.AlterarSquad(It.IsAny<AlterarSquadDTO>())).Returns("Colaborador não encontrado");

            AlterarSquadUseCase useCase = new AlterarSquadUseCase(_repositoryMock.Object, _retornarDadosDoColaboradorUseCaseMock.Object, _retornarListaDeSquadsUseCaseMock.Object);

            var response = useCase.AlterarSquad(new AlterarSquadDTO());

            Assert.Equal("Colaborador não encontrado", response);

        }

        [Fact]
        public void AlterarSquadComSquadNaoEncontrada()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Cpf = "123";

            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);

            List<SquadDTO> listaSquadDTO = new List<SquadDTO>();
            SquadDTO squadDTO = new SquadDTO();
            squadDTO.Nome = "E2A";
            squadDTO.IdSquad = 1;
            listaSquadDTO.Add(squadDTO);

            _retornarListaDeSquadsUseCaseMock.Setup(a => a.ObterListaDeSquads()).Returns(listaSquadDTO);

            AlterarSquadUseCase useCase = new AlterarSquadUseCase(_repositoryMock.Object,
                _retornarDadosDoColaboradorUseCaseMock.Object,
                _retornarListaDeSquadsUseCaseMock.Object);

            AlterarSquadDTO alterarSquadDTO = new AlterarSquadDTO();
            alterarSquadDTO.IdSquad = 2;
            var response = useCase.AlterarSquad(alterarSquadDTO);

            Assert.Equal("Squad não encontrada", response);
        }
    }
}
