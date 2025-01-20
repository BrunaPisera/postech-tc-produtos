using Produtos.Core.Entities.Enums;
using Produtos.Core.ValueObjects;

namespace Produtos.Core.Entities
{
    public class ProdutoAggregate : Entity<int>, IAggregateRoot
    {
        public string Nome { get; set; }
        public Preco Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}
