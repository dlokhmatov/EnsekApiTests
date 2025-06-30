using EnsekApiTests.Models;
using EnsekApiTests.Utilities;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using RestSharp;

namespace EnsekApiTests.Services
{
    public class ApiClient : IApiClient
    {
        private readonly RestClient _client;
        private readonly IConfiguration _configuration;
        private string _token;

        private readonly string urlPath = "ENSEK";

        public ApiClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new RestClient(configuration["BaseUrl"]!);
        }

        public string Authenticate()
        {
            var loginRequest = new Login
            {
                username = _configuration["Credentials:UserName"]!,
                password = _configuration["Credentials:Password"]!
            };

            var request = new RestRequest($"{urlPath}/login", Method.Post);
            request.AddJsonBody(loginRequest);

            var response = _client.Execute<LoginResponse>(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseData = JsonHelper.DeserializeResponse<LoginResponse>(response.Content!);

            _token = responseData.AccessToken;

            return _token;
        }

        public LoginResponse PostLogin(Login login)
        {
            var request = new RestRequest($"{urlPath}/login", Method.Post);
            request.AddJsonBody(login);

            var response = _client.Execute<LoginResponse>(request);

            var responseData = JsonHelper.DeserializeResponse<LoginResponse>(response.Content!);

            return responseData!;
        }

        public Response PutBuy(Order order)
        {
            var request = new RestRequest($"{urlPath}/buy/{order.Id}/{order.Quantity}", Method.Put);
            request.AddHeader("Authorization", $"Bearer {_token}");

            var response = _client.Execute(request);

            var responseData = JsonHelper.DeserializeResponse<Response>(response.Content!);

            return responseData!;
        }

        public RestResponse PutOrder(string endpoint, Order order)
        {
            var request = new RestRequest($"{urlPath}/buy/{order.Id}/{order.Quantity}", Method.Put);
            request
                .AddHeader("Authorization", $"Bearer {_token}")
                .AddJsonBody(order);

            var response = _client.Execute(request);

            return response;
        }

        public RestResponse DeleteOrders(string endpoint, Order order)
        {
            var request = new RestRequest($"{urlPath}/orders/{order.Id}", Method.Delete);
            request.AddHeader("Authorization", $"Bearer {_token}");

            var response = _client.Execute(request);

            return response;
        }

        public List<EnergyEntity> GetEnergy()
        {
            var request = new RestRequest($"{urlPath}/energy", Method.Get);
            request.AddHeader("Authorization", $"Bearer {_token}");

            var response = _client.Execute(request);

            var energyData = JsonHelper.DeserializeResponse<List<EnergyEntity>>(response.Content!);

            return energyData;
        }
    }
}
