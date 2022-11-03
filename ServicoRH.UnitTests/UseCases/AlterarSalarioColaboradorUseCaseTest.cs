using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.DTO;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class AlterarSalarioColaboradorUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();
        private readonly Mock<IRetornarDadosDoColaboradorUseCase> _retornarDadosDoColaboradorUseCaseMock = new Mock<IRetornarDadosDoColaboradorUseCase>();

        [Fact]
        public void AlterarSalarioColaboradorComSucesso()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Cpf = "123";
            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);
            _repositoryMock.Setup(a => a.AlterarSalarioColaborador(It.IsAny<AlterarSalarioColaboradorDTO>())).Returns("Alteração realizada com sucesso");

            AlterarSalarioColaboradorUseCase useCase = new AlterarSalarioColaboradorUseCase(_repositoryMock.Object, _retornarDadosDoColaboradorUseCaseMock.Object);

            AlterarSalarioColaboradorDTO dto = new AlterarSalarioColaboradorDTO();

            var response = useCase.AlterarSalario(dto);

            Assert.Equal("Alteração realizada com sucesso", response);
        }

        [Fact]
        public void AlterarSalarioColaboradorComUsuarioNaoEncontrado()
        {
            Colaborador colaborador = new Colaborador();

            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);
            _repositoryMock.Setup(a => a.AlterarSalarioColaborador(It.IsAny<AlterarSalarioColaboradorDTO>())).Returns("Usuário não encontrado");

            AlterarSalarioColaboradorUseCase useCase = new AlterarSalarioColaboradorUseCase(_repositoryMock.Object, _retornarDadosDoColaboradorUseCaseMock.Object);

            AlterarSalarioColaboradorDTO dto = new AlterarSalarioColaboradorDTO();

            var response = useCase.AlterarSalario(dto);

            Assert.Equal("Usuário não encontrado", response);
        }
    }
}
