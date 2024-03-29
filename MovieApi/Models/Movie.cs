﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
	[Table("movies")]
	public class Movie
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[Required]
		public string? Url { get; set; }

		[Required]
		public Genre? Genre { get; set; }
	}
	
}

