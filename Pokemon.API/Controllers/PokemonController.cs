using Microsoft.AspNetCore.Mvc;

using Pokemon.API.Domain;
using Pokemon.API.Interfaces;
using Pokemon.API.Services;

using System.Threading.Tasks;

namespace Pokemon.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemon _pokemon;
        private readonly PokemonServices _pokemonServices;

        public PokemonController(IPokemon pokemon, PokemonServices pokemonServices)
        {
            _pokemon = pokemon;
            _pokemonServices = pokemonServices;
        }

        [Route("getPokemones")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _pokemon.GetPokemones();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pokemon.GetPokemon(id);

            return Ok(result);
        }

        [Route("CadastroPokemonMestre")]
        [HttpPost]
        public async Task<IActionResult> CadastroPokemonMestre(PokemonModel mestrePokemon)
        {
            var pokemonMestre = await _pokemonServices.CadastrarPokemonMestre(mestrePokemon);

            return Ok(pokemonMestre);
        }

        [Route("PokemonCapturado")]
        [HttpPost]
        public async Task<IActionResult> PokemonCapturado(int idDoPokemonCapturado)
        {
            var pokemon = await _pokemon.GetPokemon(idDoPokemonCapturado);

            var pokemonCapturado = await _pokemonServices.CadastrarPokemonCapturado(pokemon);

            return Ok(pokemonCapturado);
        }

        [Route("ListarPokemonsCapturado")]
        [HttpGet]
        public async Task<IActionResult> ListarPokemonsCapturado()
        {
            var pokemonCapturados = await _pokemonServices.ListarPokemonCapturados();

            return Ok(pokemonCapturados);
        }
    }
}
