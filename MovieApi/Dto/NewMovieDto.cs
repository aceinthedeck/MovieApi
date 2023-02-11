using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dto
{
	public class NewMovieDto
	{
        [Required]
        public string name { get; set; }
    }
}

