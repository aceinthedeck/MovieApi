using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }

		
	}
}

