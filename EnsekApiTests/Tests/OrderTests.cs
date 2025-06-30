using EnsekApiTests.Tests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace EnsekApiTests.Tests
{
    [TestFixture]
    public class OrderTests : BaseTest
    {
        [Test]
        public void PutBuyWithValidData()
        {
            //Arrange
            var orderRequest = new OrderTestDataBuilder()
                .WithId("1")
                .WithQuantity(100)
                .Build();

            //Act
            var response = _client.PutBuy(orderRequest);

            //Assert
            response.Message.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void PutBuyWithInvalidId()
        {
            var orderRequest = new OrderTestDataBuilder()
                .WithId("-1")
                .WithQuantity(100)
                .Build();

            //Act
            var response = _client.PutBuy(orderRequest);

            //Assert
            response.Message.Should().Be("Not Found");
        }

        [Test]
        public void PutBuyWithInvalidQuantity()
        {
            //Arrange
            var orderRequest = new OrderTestDataBuilder()
                .WithId("3")
                .WithQuantity(-100)
                .Build();

            //Act
            var response = _client.PutBuy(orderRequest);

            //Assert
            response.Message.Should().Be("Not Found");
        }
    }
}
