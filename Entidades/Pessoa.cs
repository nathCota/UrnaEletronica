
namespace Entidades
{
    public abstract class Pessoa
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }

        public Pessoa()
        {
            Id = Guid.NewGuid();
        }

    }
}
