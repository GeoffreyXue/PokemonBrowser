using Newtonsoft.Json;

namespace PokemonBrowser.Models.JsonResponse
{
    public class PokemonListResponse
    {
        [JsonProperty(PropertyName = "next")]
        public string NextURL { get; set; }
        [JsonProperty(PropertyName = "previous")]
        public string PreviousURL { get; set; }
        [JsonProperty(PropertyName = "results")]
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
