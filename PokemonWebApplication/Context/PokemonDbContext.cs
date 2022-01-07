using Microsoft.EntityFrameworkCore;

using PokemonWebApplication.Models;

namespace PokemonWebApplication.Context
{
    public class PokemonDbContext : DbContext
    { 
            public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
            {

            }

            public DbSet<MestrePokemon> MestrePokemon { get; set; }
        }
 
}
