using JokesApiDemo.Dtos;
using JokesApiDemo.Models;

namespace JokesApiDemo.Services;

public interface IJokesService
{
    Task<Joke> GetJoke();

    Task<JokeCountDto> GetJokeCount();
}
