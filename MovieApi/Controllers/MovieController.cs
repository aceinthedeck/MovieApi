using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Dto;
using MovieApi.Models;
using MovieApi.Services;
using static System.Net.Mime.MediaTypeNames;

namespace MovieApi.Controllers
{
    [Route("movies")]
	public class MovieController : BaseController<MovieController>
	{
		private readonly IMovieService _movieService;
        private readonly IFileUploadService _fileUploadService;
        private readonly IWebHostEnvironment _webHostEnvironment;

		public MovieController(IMovieService movieService,
            ILogger<MovieController> logger,
            IFileUploadService fileUploadService,
            IWebHostEnvironment webHostEnvironment
            ) : base(logger)
		{
			_movieService = movieService;
            _fileUploadService = fileUploadService;
            _webHostEnvironment = webHostEnvironment;
		}

        [HttpGet("{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var currency = await _movieService.FindByName(name);
            if (currency == null)
            {
                return NotFound();
            }
            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string name, [FromForm] IFormFile image)
        {
            var newMovie = new Movie();
            newMovie.Name = name;

            if (image == null || image.Length == 0)
            {
                return BadRequest("File is empty");
            }

            // webroot path
            string webRoot = _webHostEnvironment.WebRootPath;

            var str = Environment.GetEnvironmentVariable("Test");
            if(str == null)
            {

            }

            // get extension of the uploaded file
            string extension = Path.GetExtension(image.FileName);

            // generate a file name, using GUID to avoid duplicates
            string fileName = Path.Combine(webRoot + Guid.NewGuid().ToString() + extension);

            try
            {
                // upload the file
                string uploadedFileUrl = await _fileUploadService.UploadFile(image, fileName);
                // assign the new file url to the db model
                newMovie.Url = uploadedFileUrl;
                // save the details in db
                newMovie = await _movieService.Create(newMovie);

            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(newMovie);

        }
    }
}

