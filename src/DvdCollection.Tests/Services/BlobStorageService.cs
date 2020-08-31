using DvdCollection.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace DvdCollection.Tests.Services
{
    [TestClass]
    public class BlobStorageService : BaseTest
    {
        [TestMethod]
        public void UploadFile_Valid_Ok()
        {
            var svc = new Core.Services.BlobStorageService(_config.GetSection("ConnectionStrings")["BlobStorage"]);
            var containerName = _config.GetSection("AppSettings")["ContainerName"];
            var newFileName = Path.GetFileName(Path.GetTempFileName());

            var filePathToUpload = Directory.EnumerateFiles(Path.GetTempPath(), "*", SearchOption.TopDirectoryOnly).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(filePathToUpload))
            {
                filePathToUpload = Path.GetTempFileName();
            }

            var result = svc.UploadAsync(filePathToUpload, containerName, newFileName).Result;
            Assert.IsTrue(result.IsSuccess, "Failed to upload file: " + result.Message);

            var cleanupResult = svc.DeleteAsync(containerName, newFileName).Result;
            Assert.IsTrue(cleanupResult.Value, "Failed to delete test upload file: " + cleanupResult.Message);
        }

        [TestMethod]
        public void DownloadFileToStream_Valid_Ok()
        {
            var svc = new Core.Services.BlobStorageService(_config.GetSection("ConnectionStrings")["BlobStorage"]);
            var containerName = _config.GetSection("AppSettings")["ContainerName"];
            var fileName = "Grosse Pointe Blank-1.m4v";
            var newFilePath = Path.GetTempFileName();

            var result = svc.DownloadToStreamAsync(containerName, fileName, newFilePath).Result;

            Assert.IsTrue(result.IsSuccess, "Failed to download file: " + result.Message);

            File.Delete(newFilePath);
        }

    }
}
