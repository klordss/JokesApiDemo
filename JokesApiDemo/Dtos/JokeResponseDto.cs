using JokesApiDemo.Models;
using Newtonsoft.Json;

namespace JokesApiDemo.Dtos;

public class JokeResponseDto
{
    public bool success { get; set; }
    
    public List<Joke> body { get; set; }
}
