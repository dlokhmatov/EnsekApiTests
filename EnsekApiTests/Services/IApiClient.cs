using EnsekApiTests.Models;
using RestSharp;

namespace EnsekApiTests.Services
{
    public interface IApiClient
    {
        string Authenticate();
        LoginResponse PostLogin(Login login);
        List<EnergyEntity> GetEnergy();
        Response PutBuy(Order order);
        RestResponse PutOrder(string endpoint, Order order);
        RestResponse DeleteOrders(string endpoint, Order order);
    }
}
