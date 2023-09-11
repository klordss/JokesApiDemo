using JokesClient.Services;
using Microsoft.AspNetCore.Components;

namespace JokesClient.Pages
{
    public partial class Counter
    {

        [Inject]
        public IJokeService _jokeService { get; private set; }


        private int currentCount = 0;

        private async Task IncrementCount()
        {
            var result = await _jokeService.GetJokeCount();

            currentCount = result.body;
        }
    }
}
