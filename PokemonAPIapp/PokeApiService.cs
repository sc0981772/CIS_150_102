using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonAPIapp
{
    public class PokeApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<Pokemon> GetPokemonAsync(string nameOrId)
        {
            try
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{nameOrId}";
                HttpResponseMessage response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Error: Unable to fetch Pokémon data.");
                    return null;
                }

                string jsonResponse = await response.Content.ReadAsStringAsync();
                Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(jsonResponse);
                return pokemon;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
