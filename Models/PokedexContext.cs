using System.Data.Entity;

namespace ApiPokedex.Models
{
    public class PokedexContext : DbContext
    {
        public PokedexContext() : base("name=PokedexConnection") { }

        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Pokemon> Pokemones { get; set; }
    }
}