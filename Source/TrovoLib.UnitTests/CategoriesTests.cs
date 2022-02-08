using NUnit.Framework;
using TrovoLib.Api;

namespace TrovoLib.UnitTests
{
    public class Tests
    {
        private TrovoAPI API;

        [SetUp]
        public void Setup()
        {
            var config = UnitTestsUtils.LoadConfiguration();

            API = new TrovoAPI();
            API.ClientID = config["Client-ID"];
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}