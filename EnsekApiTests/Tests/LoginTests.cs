using EnsekApiTests.Tests.TestData;
using FluentAssertions;
using NUnit.Framework;

namespace EnsekApiTests.Tests
{
    [TestFixture]
    public class LoginTests : BaseTest
    {
        [Test]
        public void LoginWithValidCredentials()
        {

            //Arrange
            var loginRequest = new LoginTestDataBuilder()
                .WithUserName(_configuration["Credentials:UserName"])
                .WithPassword(_configuration["Credentials:Password"])
                .Build();

            //Act
            var response = _client.PostLogin(loginRequest);

            //Assert
            response.AccessToken.Should().NotBeNullOrEmpty();
            response.Message.Should().Be("Success");
        }

        [Test]
        public void LoginWithInvalidCredentials() 
        { 
            //Arrange
            var loginRequest = new LoginTestDataBuilder()
                .WithUserName(_configuration["Credentials:UserName"])
                .WithPassword("test")
                .Build();

            //Act
            var response = _client.PostLogin(loginRequest);

            //Assert
            response.Message.Should().Be("Unauthorized");
        }
    }
}
