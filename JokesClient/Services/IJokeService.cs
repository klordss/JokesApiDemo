using JokesClient.Models;

namespace JokesClient.Services
{
    public interface IJokeService
    {
        Task<Joke> GetJoke();

        Task<JokeCount> GetJokeCount();    
    }
}
