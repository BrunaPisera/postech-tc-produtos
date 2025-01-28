using Produtos.Core.Entities.Enums;
using Produtos.Core.ValueObjects;

namespace Produtos.Core.Entities
{
    public class ProdutoAggregate : Entity<string>, IAggregateRoot
    {
        public ProdutoAggregate(string id) : base(id)
        {
        }

        public string Nome { get; set; }
        public Preco Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}
