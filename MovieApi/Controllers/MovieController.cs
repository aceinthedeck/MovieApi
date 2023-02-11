using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Dto;
using MovieApi.Models;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [Route("movies")]
	public class MovieController : BaseController<MovieController>
	{
		private readonly IMovieService _movieService;

		public MovieController(IMovieService movieService, ILogger<MovieController> logger) : base(logger)
		{
			_movieService = movieService;
		}

        [HttpGet("{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var currency = await _movieService.FindByName(name);
            if (currency == null)
            {
                return NotFound();
            }
            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewMovieDto newCurrencyDto)
        {
            var newMovie = new Movie();
            newMovie.Name = newCurrencyDto.name;

            try
            {
                newMovie = await _movieService.Create(newMovie);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Error in input or duplicate movie");
            }

            return Ok(newMovie);

        }
    }
}

