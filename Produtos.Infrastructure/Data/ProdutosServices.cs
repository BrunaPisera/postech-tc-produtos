using MongoDB.Driver;
using Produtos.Core.Entities;
using Produtos.Core.Entities.Enums;
using Produtos.Infrastructure.Model;
using Produtos.UseCases.Gateway;

namespace Produtos.Infrastructure.Data
{
    public class ProdutosServices : IProdutoPersistenceGateway
    {
        private readonly IMongoCollection<Produto> _produtosCollection;
        public ProdutosServices() 
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
            if (connectionString == null)
            {
                Environment.Exit(0);
            }
            var client = new MongoClient(connectionString);
            _produtosCollection = client.GetDatabase("produtos_db").GetCollection<Produto>("Produtos");
        }

        public Task<ProdutoAggregate?> GetProdutoByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProdutoAggregate>> GetProdutosByCategoriaAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProdutoAggregate>> GetProdutosByIdsAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public bool RemoveProduto(ProdutoAggregate produtoAggregate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProdutoAsync(ProdutoAggregate produtoCadastrado)
        {
            throw new NotImplementedException();
        }
    }
}
