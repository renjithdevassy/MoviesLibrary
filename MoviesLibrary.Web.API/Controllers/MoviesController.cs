using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.API.Models;
using MoviesLibrary.Core.Domain;

namespace MoviesLibrary.Web.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesReader _moviesReader;
        public MoviesController(IMoviesReader moviesReader)
        {
            _moviesReader = moviesReader;
        }
        [HttpGet("getall")]
        public async Task<List<MoviesModel>> GetAll()
        {
            var movies = await _moviesReader.GetAll();
            return movies;
        }
    }
}
