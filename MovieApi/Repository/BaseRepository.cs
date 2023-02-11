using System;
namespace MovieApi.Repository
{
	public abstract class BaseRepository
	{
		protected readonly ApplicationDbContext _dbContext;

		public BaseRepository(ApplicationDbContext context)
		{
			_dbContext = context;
		}
	}
}

