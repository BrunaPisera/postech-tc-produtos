namespace Produtos.Core
{
    public class Entity<T>
    {
        public T Id { get; }

        public Entity(T id)
        {
            Id = id;
        }
    }
}
