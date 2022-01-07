using System.Net.Http;
using System;

namespace Pokemon.API.Helper
{
    public class PokeAPI
    {
		public HttpClient initial()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");

			return client;
		}
	}
}
