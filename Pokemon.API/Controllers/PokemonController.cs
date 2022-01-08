using Microsoft.AspNetCore.Mvc;

using Pokemon.API.Domain;
using Pokemon.API.Dto;
using Pokemon.API.Interfaces;
using Pokemon.API.Services;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Pokemon.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemon _pokemon;
        private readonly PokemonServices _pokemonServices;
        protected ResponseDto _response;

        public PokemonController(IPokemon pokemon, PokemonServices pokemonServices)
        {
            _pokemon = pokemon;
            _pokemonServices = pokemonServices;
            _response = new ResponseDto();
        }

        [Route("getPokemones")]
        [HttpGet]
        public async Task<Object> Get()
        {
            try
            {
                var result = await _pokemon.GetPokemones();

                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet("{id}")]
        public async Task<Object> GetById(int id)
        {
            try
            {
                var result = await _pokemon.GetPokemon(id);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [Route("CadastroPokemonMestre")]
        [HttpPost]
        public async Task<Object> CadastroPokemonMestre([FromBody]PokemonModel mestrePokemon)
        {

            try
            {
                if (ModelState.IsValid) 
                {
                    var result = await _pokemonServices.CadastrarPokemonMestre(mestrePokemon);

                    _response.Result = result;
                }
                else
                {
                    _response.isSuccess = false;

                    return HttpStatusCode.BadRequest;

                }
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [Route("PokemonCapturado")]
        [HttpPost]
        public async Task<Object> PokemonCapturado(int idDoPokemonCapturado)
        {
            try
            {
                var pokemon = await _pokemon.GetPokemon(idDoPokemonCapturado);

                var result = await _pokemonServices.CadastrarPokemonCapturado(pokemon);

                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [Route("ListarPokemonsCapturado")]
        [HttpGet]
        public async Task<Object> ListarPokemonsCapturado()
        {
            try
            {
                var result = await _pokemonServices.ListarPokemonCapturados();

                _response.Result = result;  

            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
