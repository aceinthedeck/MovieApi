using System;
using MovieApi.Models;

namespace MovieApi.Dto
{
	public class MovieListDto
	{
        public IEnumerable<Movie> movies { get; set; }
    }
}

