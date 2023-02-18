using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Repository
{
	public class GenreRepository : BaseRepository, IGenreRepository
	{
		public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<Genre> Add(Genre genre)
        {
            _dbContext.Genres.Add(genre);
            await _dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre> FindById(Guid id)
        {
            return await _dbContext.Genres
                            .Where(g => g.Id == id)
                            .Include(g => g.Movies)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Genre>> FindAll()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task Delete(Genre genre)
        {
            _dbContext.Remove(genre);
            await _dbContext.SaveChangesAsync();
        }

    }
}

