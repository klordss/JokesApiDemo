using JokesClient.Models;
using System.Text.Json;

namespace JokesClient.Services.Implementors
{
    public class JokeService : IJokeService
    {
        private HttpClient _httpClient;

        public JokeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Joke> GetJoke()        
        {
            var url = "https://localhost:7137/api/jokes";

            var httpResponse = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            var jsonResponse = JsonSerializer.Deserialize<Joke>(response);

            return jsonResponse;
        }

        public async Task<JokeCount> GetJokeCount()
        {
            var url = "https://localhost:7137/api/jokes/count";

            var httpResponse = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();
            var response = await httpResponse.Content.ReadAsStringAsync();

            var jsonResponse = JsonSerializer.Deserialize<JokeCount>(response);

            return jsonResponse;
        }
    }
}
