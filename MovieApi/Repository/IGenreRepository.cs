using System;
using MovieApi.Models;

namespace MovieApi.Repository
{
	public interface IGenreRepository
	{
        Task<Genre> Add(Genre movie);
        Task<Genre> FindById(Guid id);
        Task<IEnumerable<Genre>> FindAll();
    }
}

