
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Pokemon.API.Context;
using Pokemon.API.Domain;
using Pokemon.API.Helper;
using Pokemon.API.Interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokemon.API.Services
{
    public class PokemonServices : IPokemon
    {
        PokeAPI _api = new PokeAPI();

        private readonly PokemonContext _dbContext;

        public PokemonServices(PokemonContext pokemonContext)
        {
            _dbContext = pokemonContext;

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

        public async Task<PokemonModel> CadastrarPokemonCapturado(Rootobject pokemonObj)
        {
            var pokemon = new PokemonModel
            {
                Id = pokemonObj.id,
                Nome = pokemonObj.name
            };

            return await CreateUpdatePokemon(pokemon);
        }

        public async Task<PokemonModel> CadastrarPokemonMestre(PokemonModel pokemonModel)
        {
            _dbContext.Pokemon.Add(pokemonModel);
            await _dbContext.SaveChangesAsync();

            return pokemonModel;
        }

        public async Task<List<PokemonModel>> ListarPokemonCapturados()
        {
            var pokemonCapturados = await GetAllPokemons();

            return pokemonCapturados.Where(x => x.PokemonFoiCapturado == true).ToList();
        }

        private async Task<List<PokemonModel>> GetAllPokemons()
        {
            var pokemons = await _dbContext.Pokemon.ToListAsync();

            return pokemons;
        }

        private async Task<PokemonModel> CreateUpdatePokemon(PokemonModel pokemon)
        {
            if (pokemon.Id > 0)
                _dbContext.Update(pokemon);
            else
                _dbContext.Pokemon.Add(pokemon);

            await _dbContext.SaveChangesAsync();

            return pokemon;
        }
    }
}
