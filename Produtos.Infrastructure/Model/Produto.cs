using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Produtos.Core.Entities.Enums;
using Produtos.Core.ValueObjects;

namespace Produtos.Infrastructure.Model
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string? Id { get; set; }
        public string Nome { get; set; }
        public Preco Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}