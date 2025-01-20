using Microsoft.Extensions.DependencyInjection;
using Produtos.UseCases;
using Produtos.UseCases.Interfaces;

namespace Produtos.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {            
            services.AddScoped<IProdutoUseCases, ProdutoUseCases>();           

            return services;
        }
    }
}
