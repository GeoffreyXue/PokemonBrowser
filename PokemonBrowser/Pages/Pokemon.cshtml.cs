using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonBrowser.API;
using PokemonBrowser.Data;
using PokemonBrowser.Models;
using PokemonBrowser.Models.JsonResponse;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PokemonBrowser.Pages
{
    public class PokemonModel : PageModel
    {
        private readonly PokemonBrowserContext _context;
        private PokemonListResponse response;
        [BindProperty]
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
        [BindProperty]
        public string NextURL { get; set; } = string.Empty;

      

        public PokemonModel(PokemonBrowserContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            PokemonAPI.SetHttpClientFactory(httpClientFactory);
        }
        public async Task OnGetAsync(string nextURL)
        {
            // Pokemons = await _context.Pokemons.ToListAsync();
            await fetchPokemons(nextURL);
            Debug.WriteLine("New Get");
            Debug.WriteLine(NextURL);
        }

        private async Task fetchPokemons(string nextURL)
        {
            response = await PokemonAPI.FetchPokemonList(nextURL);
            NextURL = response.NextURL;
            Pokemons.AddRange(response.Pokemons);
        }
    }
}
