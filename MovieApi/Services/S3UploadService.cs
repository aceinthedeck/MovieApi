using System;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace MovieApi.Services
{
	public class S3UploadService : IFileUploadService
	{
        string awsAccessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY");
        string awsSecret =  Environment.GetEnvironmentVariable("AWS_SECRET");
        string bucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME");
        string url = $"https://{Environment.GetEnvironmentVariable("AWS_BUCKET_NAME")}.s3.amazonaws.com";

        public S3UploadService()
		{
		}

        public async Task<string> UploadFile(IFormFile file, string fileName)
        {
            await using var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);

            var uploadRequest = new TransferUtilityUploadRequest()
            {
                InputStream = memoryStream,
                Key = fileName,
                BucketName = bucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            using var client = new AmazonS3Client(awsAccessKey, awsSecret, Amazon.RegionEndpoint.USEast1);

            var transferUtility = new TransferUtility(client);

            await transferUtility.UploadAsync(uploadRequest);

            return $"{url}/{fileName}";
        }
    }
}

