
namespace Entidades
{
    public class Partido
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Sigla { get; set; }

        public Partido()
        {
            Id = Guid.NewGuid();
        }

    }
}
