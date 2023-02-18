using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dto
{
	public class NewMovieDto
	{
        [Required]
        public Guid genreId { get; set; }

        [Required]
        public string name { get; set; }
    }
}

