using Newtonsoft.Json;
using System.Diagnostics;
using PokemonBrowser.Models;
using PokemonBrowser.Models.JsonResponse;

namespace PokemonBrowser.API
{
    public static class PokemonAPI
    {
        private static IHttpClientFactory _httpClientFactory;

        public static void SetHttpClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private static bool HttpClientFactoryInitialized()
        {
            return _httpClientFactory != null;
        }
        public static async Task<PokemonListResponse> FetchPokemonList(string url)
        {
            if (!HttpClientFactoryInitialized())
            {
                Debug.WriteLine("PokeAPI HttpClientFactory not initialized");
                return null;
            }

            if (url == null) url = "https://pokeapi.co/api/v2/pokemon";

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = await httpResponseMessage.Content.ReadAsStringAsync();
                if (response == null) return null;

                PokemonListResponse responseWrapper = JsonConvert.DeserializeObject<PokemonListResponse>(response);
                if (responseWrapper == null) return null;

                return responseWrapper;
            }
            else
            {
                Debug.WriteLine("PokeAPI get Pokemon List failed to send");
                return null;
            }
        }
    }
}
