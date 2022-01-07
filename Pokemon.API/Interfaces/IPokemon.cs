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
        Task<int> CadastrarPokemonCapturado(int id);
        Task<int> CadastrarPokemonMestre(int id);
        Task<List<PokemonModel>> ListarPokemonCapturados();
    }
}
