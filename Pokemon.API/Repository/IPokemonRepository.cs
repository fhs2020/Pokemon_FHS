using Pokemon.API.Domain;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokemon.API.Repository
{
    public interface IPokemonRepository
    {
        public Task<PokemonModel> GetPokemonById(int id);
        public Task<List<PokemonModel>> GetAllPokemons();
        public Task<PokemonModel> CreateUpdatePokemon(PokemonModel pokemon);
        public Task<bool> Delete(int id);
    }
}
