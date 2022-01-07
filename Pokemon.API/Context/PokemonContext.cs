using Microsoft.EntityFrameworkCore;

using Pokemon.API.Domain;

namespace Pokemon.API.Context
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }

        public DbSet<PokemonModel> Pokemon { get; set; }
    }
}
