using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DvdCollection.Models;

namespace DvdCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("test");

            ////todo: replace hard-coded api key
            //var svc = new Core.Services.OmdbService("{replaceme}");

            ////todo: replace hard-coded movie ID
            //var movie = await svc.GetAsync("{replaceme}");

            //todo: replace hard-coded key
            //var os = new Core.Services.OmdbService("{replaceme}");
            //var ms = new Core.Services.MediaService(new Data.Context(), os);

            var ctx = new Data.Context();
            var recentMovies = ctx.MediaFiles.Take(12);

            return View("Index", recentMovies);
        }

        public async Task<ActionResult> Download(string fileName)
        {
            //todo: replace hard-coded conn str
            var bs = new Core.Services.BlobStorageService("DefaultEndpointsProtocol=https;AccountName=pauldavis;AccountKey={replaceme};EndpointSuffix=core.windows.net");
            var containerName = "dvds";

            var blob = bs.GetBlobReference(containerName, fileName);
            var blobProps = blob.GetProperties().Value;

            Response.Headers.Add("Content-Disposition", "attachment; filename=" + fileName);
            Response.Headers.ContentLength = blobProps.ContentLength;
            var response = await blob.DownloadToAsync(Response.Body);
            //await bs.DownloadToStreamAsync(containerName, fileName, Response.Body);
            return new EmptyResult();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//string inputContent;
//using (StreamReader inputStreamReader = new StreamReader(InputFileUpload.PostedFile.InputStream))
//{
//    inputContent = inputStreamReader.ReadToEnd();
//}