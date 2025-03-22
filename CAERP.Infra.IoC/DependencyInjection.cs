using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CAERP.Domains.Interfaces;
using CAERP.Infra.Data.Repositories;
using CAERP.Application.Services;
using CAERP.Application.Interfaces;

namespace CAERP.Infra.IoC
{
    public static class DependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Conexão com o Banco de Dados
            services.AddScoped<IDatabaseConnection, DatabaseConnection>(provider =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");
                }

                return new DatabaseConnection(connectionString);
            });

            // Repositórios
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            // Serviços
            services.AddScoped<IEmpresaService, EmpresaService>();
        }
    }
}
