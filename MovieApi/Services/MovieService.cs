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

        public Task Delete(Movie movie)
        {
            // normally we would test here if Genre "owns" the Movie id
            // delete logic here
            return _movieRepository.Delete(movie);
        }

        public Task<Movie> FindById(Guid id)
        {
            return _movieRepository.FindById(id);
        }

        public Task<Movie> FindByName(string name)
        {
            return _movieRepository.FindByName(name);
        }
    }
}

