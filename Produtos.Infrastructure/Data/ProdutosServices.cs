using MongoDB.Bson;
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

        public async Task<ProdutoAggregate?> GetProdutoByIdAsync(string id)
        {
            var produto =  await _produtosCollection.Find(p => p.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();

            if (produto == null) return null;

            return new ProdutoAggregate (produto.Id.ToString())
            {
                Nome = produto.Nome,
                Preco = produto.Preco,
                Categoria = (Categoria)produto.Categoria, 
            };
        }
        
        public async Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome)
        {
           var produto =  await _produtosCollection.Find(p => p.Nome == nome).FirstOrDefaultAsync();

            if (produto == null) return null;

            return new ProdutoAggregate(produto.Id.ToString())
            {
                Nome = produto.Nome,
                Preco = produto.Preco,
                Categoria = (Categoria)produto.Categoria,
            };
        }

        public async Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync()
        {
            var produtos = await _produtosCollection.Find(_ => true).ToListAsync();

            return produtos.Select(x =>
            {
                return new ProdutoAggregate(x.Id.ToString())
                {
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Categoria = (Categoria)x.Categoria,
                };
            });
        }

        public async Task<IEnumerable<ProdutoAggregate>> GetProdutosByCategoriaAsync(Categoria categoria)
        {
            var produtos = await _produtosCollection.Find(p => p.Categoria == categoria).ToListAsync();

            return produtos.Select(x =>
            {
                return new ProdutoAggregate(x.Id.ToString())
                {
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Categoria = (Categoria)x.Categoria,
                };
            });
        }

        public async Task<List<ProdutoAggregate>> GetProdutosByIdsAsync(IEnumerable<int> ids)
        {
            var filter = Builders<Produto>.Filter.In("Id", ids);

            var produtos = await _produtosCollection
                                .Find(filter)
                                .ToListAsync();

            return produtos.Select(x =>
            {
                return new ProdutoAggregate(x.Id.ToString())
                {
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Categoria = (Categoria)x.Categoria,
                };
            }).ToList();
        }

        public bool RemoveProduto(ProdutoAggregate produtoAggregate)
        {
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, ObjectId.Parse(produtoAggregate.Id));
           
            var result = _produtosCollection.DeleteOne(filter);
                        
            return result.DeletedCount > 0;
        }

        public async Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate)
        {
            var produto = new Produto() 
            {            
                Id = ObjectId.GenerateNewId(),
                Nome = produtoAggregate.Nome,
                Categoria = produtoAggregate.Categoria,
                Preco = produtoAggregate.Preco,
            };

            //try
            //{                
                await _produtosCollection.InsertOneAsync(produto);

                return true;
            //}
            //catch
            //{             
            //    return false;
            //}
        }

        public async Task<bool> UpdateProdutoAsync(ProdutoAggregate produtoCadastrado)
        {        
            var filter = Builders<Produto>.Filter.Eq(p => p.Id, ObjectId.Parse(produtoCadastrado.Id));
                       
            var update = Builders<Produto>.Update
                .Set(p => p.Nome, produtoCadastrado.Nome)
                .Set(p => p.Preco, produtoCadastrado.Preco)
                .Set(p => p.Categoria, produtoCadastrado.Categoria);           

            try
            {
                await _produtosCollection.UpdateOneAsync(filter, update);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
