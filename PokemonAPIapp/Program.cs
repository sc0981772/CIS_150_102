using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonAPIapp
{
    public class Program
    {
        private static List<Pokemon> requestedPokemonList = new List<Pokemon>();

        public static async Task Main(string[] args)
        {
            PokeApiService pokeApiService = new PokeApiService();

            while (true)
            {
                Console.WriteLine("Enter a Pokémon name or ID (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    break;

                Pokemon pokemon = await pokeApiService.GetPokemonAsync(input);

                if (pokemon != null)
                {
                    requestedPokemonList.Add(pokemon);
                    Console.WriteLine($"Name: {pokemon.Name}, Height: {pokemon.Height}, Weight: {pokemon.Weight}");
                }

                Console.WriteLine("Previously Requested Pokémon:");
                foreach (var p in requestedPokemonList)
                {
                    Console.WriteLine($"- {p.Name}");
                }
            }
        }
    }
}
