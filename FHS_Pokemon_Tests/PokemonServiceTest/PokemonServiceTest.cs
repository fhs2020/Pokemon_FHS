using Microsoft.EntityFrameworkCore;

using Pokemon.API.Context;
using Pokemon.API.Services;

using System.Threading.Tasks;

using Xunit;

namespace FHS_Pokemon_Tests
{
    public class PokemonServiceTest
    {

        public PokemonServiceTest()
        {

        }

        [Fact]
        public async Task ListaPokemons()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<PokemonContext>();
            optionsBuilder.UseSqlite("name=ConnectionStrings:DefaultConnection");


            using (var context = new PokemonContext(optionsBuilder.Options))
            {
                var service = new PokemonServices(context);
                
                // Act 
                var list = await service.GetPokemones();
                
                // Assert
                Assert.NotNull(list);
            }

        }

    }
}
