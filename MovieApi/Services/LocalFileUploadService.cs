using System;

namespace MovieApi.Services
{
	public class LocalFileUploadService : IFileUploadService
	{
		public LocalFileUploadService()
		{
		}

        public async Task<string> UploadFile(IFormFile file, string fileName)
        {
            // create a file at fileName path
            using(var fileStream = new FileStream(fileName, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                fileStream.Close();
            }

            //Return the path of file name after upload
            return fileName;
        }
    }
}

