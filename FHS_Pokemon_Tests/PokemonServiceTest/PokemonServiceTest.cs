using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Moq;

using Pokemon.API.Context;
using Pokemon.API.Domain;
using Pokemon.API.Interfaces;
using Pokemon.API.Services;

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

            var mockSet = new Mock<DbSet<PokemonModel>>();

            var mockContext = new Mock<PokemonContext>(optionsBuilder);

           // mockContext.Setup(m => m.Pokemon).Returns(mockSet.Object);

            using (var context = new PokemonContext(optionsBuilder.Options))
            {
                var service = new PokemonServices(context);
                var list = await service.GetPokemones();
                Assert.NotNull(list);
            }

            // Act
            //var result = await pokemonService.GetPokemones();

            // Asser
            //Assert.True(result.results.Any());

        }
 
    }
}
