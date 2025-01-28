using Microsoft.Extensions.DependencyInjection;
using Produtos.Infrastructure.Data;
using Produtos.UseCases;
using Produtos.UseCases.Gateway;
using Produtos.UseCases.Interfaces;

namespace Produtos.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {            
            services.AddScoped<IProdutoUseCases, ProdutoUseCases>();
            services.AddScoped<IProdutoPersistenceGateway, ProdutosServices>();

            return services;
        }
    }
}