using Produtos.Core.Entities.Enums;
using Produtos.Core.Entities;

namespace Produtos.UseCases.Gateway
{
    public interface IProdutoPersistenceGateway
    {
        Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate);
        Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome);
        Task<ProdutoAggregate?> GetProdutoByIdAsync(string id);
        Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync();
        Task<IEnumerable<ProdutoAggregate>> GetProdutosByCategoriaAsync(Categoria categoria);
        bool RemoveProduto(ProdutoAggregate produtoAggregate);
        Task<bool> UpdateProdutoAsync(ProdutoAggregate produtoCadastrado);
        Task<List<ProdutoAggregate>> GetProdutosByIdsAsync(IEnumerable<int> ids);
    }
}
