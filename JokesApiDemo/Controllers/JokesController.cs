using JokesApiDemo.Dtos;
using JokesApiDemo.Models;
using JokesApiDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JokesApiDemo.Controllers
{
    [ApiController]
    [Route("api/jokes")]
    public class JokesController : ControllerBase
    {

        private readonly ILogger<JokesController> _logger;
        private readonly IJokesService _jokesService;

        public JokesController(ILogger<JokesController> logger, IJokesService jokesService)
        {
            _logger = logger;
            _jokesService = jokesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetJokeAsync()
        {

            Joke jokeResponse = null;

            try
            {
                jokeResponse = await _jokesService.GetJoke();

                if (jokeResponse != null) {
                    _logger.LogInformation("returning joke: {joke}", jokeResponse);
                }
                else
                {
                    _logger.LogWarning("Unable to retrieve joke from service");
                    return NotFound("Service unable");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception");

                return BadRequest("Exception while running the request");
            }

            return Ok(jokeResponse);
        }


        [HttpGet]
        [Route("count")]
        public async Task<IActionResult> GetJokeCount()
        {
            JokeCountDto jokeResponse = null;

            try
            {
                jokeResponse = await _jokesService.GetJokeCount();

                if (jokeResponse != null)
                {
                    _logger.LogInformation("returning joke: {jokes count}", jokeResponse);
                }
                else
                {
                    _logger.LogWarning("Unable to retrieve joke from service");
                    return NotFound("Service unable");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception");

                return BadRequest("Exception while running the request");
            }

            return Ok(jokeResponse);
        }
        
    }
}