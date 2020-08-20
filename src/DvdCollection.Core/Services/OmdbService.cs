using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DvdCollection.Core.Services
{
    public class OmdbService : IService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OmdbService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<Models.Imdb.Movie> GetAsync(string imdbId)
        {
            var response = await _httpClient.GetAsync("http://" + $"www.omdbapi.com/?apikey={_apiKey}&i={imdbId}");
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Call to API failed: " + response.ReasonPhrase + "\n" + result);
            }

            return JsonConvert.DeserializeObject<Models.Imdb.Movie>(result);
        }

    }
}
