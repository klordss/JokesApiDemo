using JokesClient.Services;
using Microsoft.AspNetCore.Components;

namespace JokesClient.Pages
{
    public partial class Index
    {
        [Inject]
        public IJokeService _jokeService { get; private set; }

        private string currentJoke;

        private async Task GenerateJoke()
        {
            // You can implement code here to fetch a new joke and set it to 'currentJoke'
            // For the sake of this example, I'll just use a static joke:
            var joke = await _jokeService.GetJoke();

            if (joke != null) {
                currentJoke = string.Concat(joke.setup, System.Environment.NewLine, joke.punchline);
            }
        }
    }
}
