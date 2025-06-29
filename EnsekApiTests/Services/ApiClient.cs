using EnsekApiTests.Configuration;
using EnsekApiTests.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

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
            _client = new RestClient(configuration["BaseUrl"]);
        }

        public string Authenticate()
        {
            var loginRequest = new Login
            {
                username = _configuration["Credentials:UserName"],
                password = _configuration["Credentials:Password"]
            };

            var request = new RestRequest($"{urlPath}/login", Method.Post);
            request.AddJsonBody(loginRequest);

            var response = _client.Execute<LoginResponse>(request);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var responseData = JsonSerializer.Deserialize<LoginResponse>(response.Content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            _token = responseData.AccessToken;

            return _token;
        }

        public LoginResponse PostLogin(Login login)
        {
            var request = new RestRequest($"{urlPath}/login", Method.Post);
            request.AddJsonBody(login);

            var response = _client.Execute<LoginResponse>(request);

            var responseData = JsonSerializer.Deserialize<LoginResponse>(response.Content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return responseData;
        }

        public RestResponse PutBuy(Order order)
        {
            var request = new RestRequest($"{urlPath}/buy/{order.Id}/{order.Quantity}", Method.Put);
            request.AddHeader("Authorization", $"Bearer {_token}");

            var response = _client.Execute(request);

            return response;
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

            var energyData = JsonSerializer.Deserialize<List<EnergyEntity>>(response.Content, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return energyData;
        }



        /*        public RestRequest CreateRequest(string endpoint, Method method, string token = null)
                {
                    var request = new RestRequest(endpoint, method);

                    if (!string.IsNullOrEmpty(token))
                    {
                        request.AddHeader("Authorization", $"Bearer {token}");
                    }

                    return request;
                }

                public async Task<RestResponse> ExecuteAsync(RestRequest request)
                {
                    return await _client.ExecuteAsync(request);*/
    }
}
