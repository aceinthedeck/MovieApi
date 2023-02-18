using System;
using MovieApi.Models;

namespace MovieApi.Services
{
	public interface IMovieService
	{
		Task<Movie> FindByName(string name);

		Task<Movie> Create(Movie movie);

		Task<Movie> FindById(Guid id);

		Task Delete(Movie movie);
	}
}

