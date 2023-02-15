using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dto
{
	public class NewGenreDto
	{
        [Required]
        public string name { get; set; }
    }
}

