using JokesApiDemo.Dtos;
using JokesApiDemo.Models;
using System.Text.Json;

namespace JokesApiDemo.Services.Implementors;

public class JokesService : IJokesService
{
    private readonly IConfiguration _config;

    private HttpClient _httpClient;
    private RapidApiRequest requestValues;


    public JokesService(IConfiguration config)
    {
        _config = config;
        SetClientRequestConfig();
    }

    private void SetClientRequestConfig()
    {
        _httpClient = new HttpClient();

        requestValues = new RapidApiRequest
        {
            BaseAddress = _config["RapidApi:Url"],
            Key = _config["RapidApi:KeyName"],
            KeyValue = _config["RapidApi:KeyValue"],
            HostKey = _config["RapidApi:KeyHost"],
            HostValue = _config["RapidApi:KeyHostValue"]
        };

        _httpClient.DefaultRequestHeaders.Add(requestValues.Key, requestValues.KeyValue);
        _httpClient.DefaultRequestHeaders.Add(requestValues.HostKey, requestValues.HostValue);                
    }

    public async Task<Joke> GetJoke()
    {
        var url = string.Format($@"{requestValues.BaseAddress}random/joke");

        var httpResponse = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadAsStringAsync();

        var jsonResponse = JsonSerializer.Deserialize<JokeResponseDto>(response);

        var jokeResponse = jsonResponse.body.FirstOrDefault();    

        return jokeResponse;
    }

    public async Task<JokeCountDto> GetJokeCount()
    {
        var url = string.Format($@"{requestValues.BaseAddress}joke/count");


        var httpResponse = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        httpResponse.EnsureSuccessStatusCode();
        var response = await httpResponse.Content.ReadAsStringAsync();

        var jokeCount = JsonSerializer.Deserialize<JokeCountDto>(response);     

        return jokeCount;
    }
}
