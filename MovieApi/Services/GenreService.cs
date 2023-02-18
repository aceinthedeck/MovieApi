using System;
using MovieApi.Dto;
using MovieApi.Models;
using MovieApi.Repository;

namespace MovieApi.Services
{
	public class GenreService : IGenreService
	{
		private readonly IGenreRepository _genreRepository;
        private readonly IMovieService _movieService;

		public GenreService(IGenreRepository genreRepository)
		{
			_genreRepository = genreRepository;
		}

        public Task<Genre> Create(NewGenreDto genreDto)
        {
            var newGenre = new Genre();
            newGenre.Id = Guid.NewGuid();
            newGenre.Name = genreDto.name;
            return _genreRepository.Add(newGenre);
        }

        public Task Delete(Genre genre)
        {
            // add delete file logic
            
            return _genreRepository.Delete(genre);
        }

        public Task<IEnumerable<Genre>> FindAll()
        {
            return _genreRepository.FindAll();
        }

        public Task<Genre> FindById(Guid id)
        {
            return _genreRepository.FindById(id);
        }
    }
}

