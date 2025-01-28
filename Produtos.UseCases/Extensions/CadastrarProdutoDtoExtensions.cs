using Produtos.Core.Entities;
using Produtos.Core.ValueObjects;
using Produtos.UseCases.Dtos;

namespace Produtos.UseCases.Extensions
{
    static internal class CadastrarProdutoDtoExtensions
    {
        static internal ProdutoAggregate ToProdutoAggregate(this CadastraProdutoDto cadastraProdutoDto)
        {
            if (cadastraProdutoDto == null)
            {
                return new ProdutoAggregate(new Guid().ToString());
            }

            return new ProdutoAggregate(new Guid().ToString())
            {
                Nome = cadastraProdutoDto.Nome,
                Preco = new Preco(cadastraProdutoDto.Preco),
                Categoria = cadastraProdutoDto.Categoria,
            };
        }
    }
}
