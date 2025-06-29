using EnsekApiTests.Models;

namespace EnsekApiTests.Tests.TestData
{
    public class LoginTestDataBuilder
    {
        private string _username = "defaultUser";
        private string _password = "defaultPassowrd";

        public LoginTestDataBuilder WithUserName(string username)
        {
            _username = username;
            return this;
        }

        public LoginTestDataBuilder WithPassword(string password)
        {
            _password = password;
            return this;
        }

        public Login Build()
        {
            return new Login
            {
                username = _username,
                password = _password
            };
        }
}
}
