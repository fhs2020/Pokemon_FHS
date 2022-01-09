using Microsoft.EntityFrameworkCore;

using Pokemon.API.Context;
using Pokemon.API.Helper;
using Pokemon.API.Interfaces;
using Pokemon.API.Services;

using System.Linq;
using System.Threading.Tasks;

using Xunit;




namespace Pokemon_FH.Tests.PokemonApiTests
{
    [Collection("IPokemon")]
    public class PokemonServiceTestes
    {
        private IPokemon _pokemonService;
        PokeAPI _api = new PokeAPI();

        public PokemonServiceTestes()
        {
            var options = new DbContextOptionsBuilder<PokemonContext>()
                .UseInMemoryDatabase(databaseName: "FakeDatabase")
                .Options;

            var dbContext = new PokemonContext(options);

            _pokemonService = new PokemonServices(dbContext);

        }

        [Fact]
        public async Task ListarPokemons()
        {
            // Arrange
            //var pokemonModel = new Moc<PokemonModel>();

            // Act
            var result = await _pokemonService.GetPokemones();

            // Asser
            Assert.True(result.results.Any());




        }
    }
}
