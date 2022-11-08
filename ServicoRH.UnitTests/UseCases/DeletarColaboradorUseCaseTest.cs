using Moq;
using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Domain;
using ServicoRH.Infra.Interface;
using Xunit;

namespace ServicoRH.UnitTests.UseCases
{
    public class DeletarColaboradorUseCaseTest
    {
        private readonly Mock<IColaboradorRepository> _repositoryMock = new Mock<IColaboradorRepository>();
        private readonly Mock<IRetornarDadosDoColaboradorUseCase> _retornarDadosDoColaboradorUseCaseMock = new Mock<IRetornarDadosDoColaboradorUseCase>();

        [Fact]
        public void DeletarColaboradorComSucesso()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Cpf = "123";
            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);
            _repositoryMock.Setup(a => a.DeletarColaborador(It.IsAny<string>())).Returns("Colaborador excluído com sucesso");

            DeletarColaboradorUseCase useCase = new DeletarColaboradorUseCase(_repositoryMock.Object, _retornarDadosDoColaboradorUseCaseMock.Object);

            var response = useCase.ExcluirColaborador("123");

            Assert.Equal("Colaborador excluído com sucesso", response);
        }

        [Fact]
        public void UsuarioNaoEncontrado()
        {
            Colaborador colaborador = new Colaborador();

            _retornarDadosDoColaboradorUseCaseMock.Setup(a => a.ObterDadosDoColaborador(It.IsAny<string>())).Returns(colaborador);
            _repositoryMock.Setup(a => a.DeletarColaborador(It.IsAny<string>())).Returns("Usuário não encontrado");

            DeletarColaboradorUseCase useCase = new DeletarColaboradorUseCase(_repositoryMock.Object, _retornarDadosDoColaboradorUseCaseMock.Object);

            var response = useCase.ExcluirColaborador("123");

            Assert.Equal("Usuário não encontrado", response);
        }
    }
}
