using System;
using MovieApi.Dto;
using MovieApi.Models;

namespace MovieApi.Services
{
	public interface IGenreService
	{
        Task<Genre> FindById(Guid id);

        Task<Genre> Create(NewGenreDto genre);

        Task<IEnumerable<Genre>> FindAll();
    }
}

