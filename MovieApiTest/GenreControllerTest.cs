using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using MovieApi.Controllers;
using MovieApi.Models;
using MovieApi.Repository;
using MovieApi.Services;

namespace MovieApiTest
{
	public class GenreControllerTest
	{

		[Fact]
		public async Task newTest()
		{
			var genreService = new Mock<IGenreService>();
			var logger = new Mock<ILogger<GenreController>>();

			genreService.Setup(_ => _.FindAll()).ReturnsAsync(GetGenres());

			var genreController = new GenreController(logger.Object, genreService.Object);

			var result = (OkObjectResult) await genreController.FindAll();

			Assert.NotNull(result);
			Assert.Equal(200, result.StatusCode.Value);
		}



		public IEnumerable<Genre> GetGenres()
		{
			return new List<Genre>
			{
				new Genre{
					Id = Guid.NewGuid(),
					Name = "Genre1"
				},
                new Genre{
                    Id = Guid.NewGuid(),
                    Name = "Genre2"
                },

            };

		}
	}
}

