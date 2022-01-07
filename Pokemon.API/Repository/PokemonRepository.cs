using Microsoft.EntityFrameworkCore;

using Pokemon.API.Context;
using Pokemon.API.Domain;
using Pokemon.API.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.API.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IPokemon _pokemon;
        private readonly PokemonContext _dbContext;

        public PokemonRepository(IPokemon pokemon, PokemonContext dbContext)
        {
            _pokemon = pokemon;
            _dbContext = dbContext;
        }

        public async Task<PokemonModel> GetPokemonById(int id)
        {
            var pokemon = await _dbContext.Pokemon.FirstOrDefaultAsync(x => x.Id == id);

            if (pokemon == null)
            {
                var result = await _pokemon.GetPokemon(id);
                pokemon = new PokemonModel
                {
                    Id = id,
                    Nome = result.name
                };
            }

            _dbContext.Pokemon.Add(pokemon);

            await _dbContext.SaveChangesAsync();

            return pokemon;
        }

        public async Task<List<PokemonModel>> GetAllPokemons()
        {
            var pokemons = await _dbContext.Pokemon.ToListAsync();

            return pokemons;
        }

        public async Task<PokemonModel> CreateUpdatePokemon(PokemonModel pokemon)
        {
            if (pokemon.Id > 0)
                _dbContext.Update(pokemon);
            else
                _dbContext.Pokemon.Add(pokemon);

            await _dbContext.SaveChangesAsync();

            return pokemon;
        }

        public async Task<bool> Delete(int id)
        {

            var pokemon = await _dbContext.Pokemon
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pokemon == null)
            {
                return false;
            }

            _dbContext.Pokemon.Remove(pokemon);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
