using System;
namespace MovieApi.Services
{
	public interface IFileUploadService
	{
		public Task<string> UploadFile(IFormFile file, string fileName);

	}
}

