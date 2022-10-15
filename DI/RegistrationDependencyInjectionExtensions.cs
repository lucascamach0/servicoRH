using ServicoRH.Application.UseCases;
using ServicoRH.Application.UseCases.Interfaces;
using ServicoRH.Infra;
using ServicoRH.Infra.Interface;

namespace ServicoRH.DI
{
    public static class RegistrationDependencyInjectionExtensions
    {
        /// <summary>
        /// Realiza o registro das dependências da aplicação.
        /// </summary>
        /// <param name="services">A coleção de serviços da aplicação.</param>
        /// <param name="configuration">As configurações da aplicação.</param>
        public static void RegistrarServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISquadRepository, SquadRepository>();
            services.AddScoped<IRetornarListaDeSquadsUseCase, RetornarListaDeSquadsUseCase>();
            services.AddScoped<IRetornarSquadPorCpfUseCase, RetornarSquadPorCpfUseCase>();
            services.AddScoped<IInserirSquadUseCase, InserirSquadUseCase>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IRetornarDadosDoColaboradorUseCase, RetornarDadosDoColaboradorUseCase>();
            services.AddScoped<IRetornarCargoDoColaboradorUseCase, RetornarCargoDoColaboradorUseCase>();
            services.AddScoped<IRetonarListaDeColaboradoresPorSquadUseCase, RetonarListaDeColaboradoresPorSquadUseCase>();
            services.AddScoped<IRetornarListaDeColaboradorPorSalarioUseCase, RetornarListaDeColaboradorPorSalarioUseCase>();
            services.AddScoped<IInserirColaboradorUseCase, InserirColaboradorUseCase>();
            services.AddScoped<IAlterarSalarioColaboradorUseCase, AlterarSalarioColaboradorUseCase>();
            services.AddScoped<IDeletarColaboradorUseCase, DeletarColaboradorUseCase>();
            services.AddScoped<IRetornarSalarioPorCpfUseCase, RetornarSalarioPorCpfUseCase>();
            services.AddScoped<IAlterarSquadUseCase, AlterarSquadUseCase>();
        }
    }
}
