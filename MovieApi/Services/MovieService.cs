using System;
using MovieApi.Models;
using MovieApi.Repository;

namespace MovieApi.Services
{
	public class MovieService : IMovieService
	{
        private readonly IMovieRepository _movieRepository;

		public MovieService(IMovieRepository movieRepository)
		{
            _movieRepository = movieRepository;
		}

        public Task<Movie> Create(Movie movie)
        {
            movie.Id = new Guid();
            return _movieRepository.Add(movie);
        }

        public Task<Movie> FindByName(string name)
        {
            return _movieRepository.FindByName(name);
        }
    }
}

