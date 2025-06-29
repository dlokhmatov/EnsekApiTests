using EnsekApiTests.Tests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace EnsekApiTests.Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {
        [Test]
        public void PutBuyTest()
        {
            var response = _client.PutBuy(OrderTestData.CreateOrder());

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}
