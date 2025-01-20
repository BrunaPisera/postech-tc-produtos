using Produtos.Core.Entities.Enums;
using Produtos.UseCases.Dtos;

namespace Produtos.UseCases.Interfaces
{
    public interface IProdutoUseCases
    {
        Task<ProdutoDto> AtualizaProdutoAsync(int id, AtualizaProdutoDto produto);
        Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync();
        Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync(Categoria nomeCategoria);
        Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto);
        Task RemoveProdutoAsync(int id);
    }
}