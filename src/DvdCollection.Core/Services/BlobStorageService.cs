using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using DvdCollection.Core.Models.Operation;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace DvdCollection.Core.Services
{
    public class BlobStorageService : IService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobStorageService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<Result<BlobContentInfo>> UploadAsync(string filePath, string containerName, string blobName, bool overwrite = false)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(blobName);

                if (!overwrite && await blobClient.ExistsAsync())
                {
                    return new Result<BlobContentInfo>("The file already exists in the contaner");
                }

                using var uploadFileStream = File.OpenRead(filePath);
                var uploadResponse = await blobClient.UploadAsync(uploadFileStream, overwrite);
                uploadFileStream.Close();

                return new Result<BlobContentInfo>(uploadResponse.Value);
            }
            catch (Exception ex)
            {
                return new Result<BlobContentInfo>(ex);
            }
        }

        public async Task<Result<bool>> DeleteAsync(string containerName, string fileName)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlobClient(fileName);

                var deleteResponse = await blobClient.DeleteAsync();

                return new Result<bool>(deleteResponse.Status == (int)HttpStatusCode.Accepted, deleteResponse.ReasonPhrase);
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

        //public async Task<Result<bool>> DownloadAsync(string containerName, string blobName, string destinationPath)
        //{
        //    try
        //    {
        //        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        //        var blobClient = containerClient.GetBlobClient(blobName);

        //        var downloadResponse = await blobClient.DownloadAsync();

        //        using (var downloadFileStream = File.OpenWrite(destinationPath))
        //        {
        //            await downloadResponse.Value.Content.CopyToAsync(downloadFileStream);
        //            downloadFileStream.Close();
        //        }

        //        return new Result<bool>(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Result<bool>(ex);
        //    }
        //}

        public async Task<Result<bool>> DownloadToStreamAsync(string containerName, string blobName, string destinationPath)
        {
            try
            {
                var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
                var blobClient = containerClient.GetBlockBlobClient(blobName);

                using (var downloadFileStream = File.OpenWrite(destinationPath))
                {
                    var downloadResponse = await blobClient.DownloadToAsync(downloadFileStream);
                    return new Result<bool>(downloadResponse.Status == (int)HttpStatusCode.Accepted, downloadResponse.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(ex);
            }
        }

    }
}
