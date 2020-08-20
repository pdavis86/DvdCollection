using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DvdCollection.Core.Services
{
    public class BlobStorageService : IService
    {
        public async Task<bool> UploadFileAsync()
        {
            var blobServiceClient = new BlobServiceClient(connectionString);

            var containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            using var uploadFileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();
        }




        // Download the blob's contents and save it to a file
        //BlobDownloadInfo download = await blobClient.DownloadAsync();

        //using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
        //{
        //    await download.Content.CopyToAsync(downloadFileStream);
        //    downloadFileStream.Close();
        //}
    }
}
