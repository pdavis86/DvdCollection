using DvdCollection.Tests.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DvdCollection.Tests.Services
{
    [TestClass]
    public class OmdbService : BaseTest
    {
        [TestMethod]
        public void Get_Valid_Ok()
        {
            //todo: replace hard-coded api key
            var svc = new Core.Services.OmdbService("14f56460");

            //todo: replace hard-coded movie ID
            var movie = svc.GetAsync("tt0088763").Result;
        }
    }
}
