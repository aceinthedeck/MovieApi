using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieApi.Models
{
	[Table("genre")]
	public class Genre
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string? Name { get; set; }

		[JsonIgnore]
		public IEnumerable<Movie> Movies { get; set; }
	}
}

