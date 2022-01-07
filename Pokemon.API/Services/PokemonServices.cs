
using Newtonsoft.Json;

using Pokemon.API.Domain;
using Pokemon.API.Helper;
using Pokemon.API.Interfaces;
using Pokemon.API.Repository;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.API.Services
{
    public class PokemonServices : IPokemon
    {
        PokeAPI _api = new PokeAPI();
        private IPokemonRepository _pokemonRepository;

        public PokemonServices(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Request> GetPokemones()
        {
            var Request = new Request();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("?limit=10&offset=1");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                Request = JsonConvert.DeserializeObject<Request>(results);
            }
            return Request;
        }

        public async Task<Rootobject> GetPokemon(int id)
        {
            var request = new Rootobject();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync($"{id}");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                request = JsonConvert.DeserializeObject<Rootobject>(results);
            }

            return request;
        }

        public async Task<int> CadastrarPokemonCapturado(int id)
        {
            return await CadastrarPokemon(id, false, true);
        }

        public async Task<int> CadastrarPokemonMestre(int id)
        {
            return await CadastrarPokemon(id, true, false);
        }

        public async Task<List<PokemonModel>> ListarPokemonCapturados()
        {
            var pokemonCapturados = await _pokemonRepository.GetAllPokemons();

            return pokemonCapturados.Where(x => x.PokemonFoiCapturado == true).ToList();
        }

        private async Task<int> CadastrarPokemon(int id, bool? ehPokemonMestre, bool? pokemonCapturado)
        {
            var pokemon = await _pokemonRepository.GetPokemonById(id);

            pokemon.PokemonFoiCapturado = ehPokemonMestre;
            pokemon.ehPokemonMestre = pokemonCapturado;

            var pokemontCapturado = _pokemonRepository.CreateUpdatePokemon(pokemon);

            return pokemontCapturado.Id;
        }

    }
}
