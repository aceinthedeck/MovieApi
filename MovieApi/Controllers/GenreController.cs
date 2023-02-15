using System;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dto;
using MovieApi.Models;
using MovieApi.Services;

namespace MovieApi.Controllers
{
	[Route("movies")]
	public class GenreController : BaseController<GenreController>
	{
		private readonly IGenreService _genreService;
		public GenreController(ILogger<GenreController> logger, IGenreService genreService) : base(logger)
		{
			_genreService = genreService;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] NewGenreDto newGenreDto)
		{

			try
			{
				return Ok(_genreService.Create(newGenreDto));
			}
			catch (Exception ex)
			{
				_logger.Log(LogLevel.Error, ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(Guid id)
		{
			var genre = await _genreService.FindById(id);

			if(genre == null)
			{
				return NotFound();
			}

			return Ok(genre);
		}

		[HttpGet]
		public async Task<IActionResult> FindAll()
		{
			return Ok(await _genreService.FindAll());
		}
	}
}

