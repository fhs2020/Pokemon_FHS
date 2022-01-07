using Pokemon.API.Domain;

using System.Collections.Generic;
using System.Threading.Tasks;

using static Pokemon.API.Domain.Rootobject;

namespace Pokemon.API.Interfaces
{
    public interface IPokemon
    {
        Task<Request> GetPokemones();
        Task<Rootobject> GetPokemon(int id);
        Task<PokemonModel> CadastrarPokemonCapturado(Rootobject pokemonObj);
        Task<PokemonModel> CadastrarPokemonMestre(PokemonModel pokemonModel);
        Task<List<PokemonModel>> ListarPokemonCapturados();
    }
}
