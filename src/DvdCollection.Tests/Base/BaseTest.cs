using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DvdCollection.Tests.Base
{
    public abstract class BaseTest
    {
        internal IConfiguration _config;

        [TestInitialize]
        public void Init()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

    }
}
