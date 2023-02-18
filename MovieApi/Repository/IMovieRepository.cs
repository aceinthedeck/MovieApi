using System;
using MovieApi.Models;

namespace MovieApi.Repository
{
	public interface IMovieRepository
	{
		Task<Movie> Add(Movie movie);
		Task<Movie> FindByName(string name);
		Task<Movie> FindById(Guid id);
		Task Delete(Movie movie);
	}
}

