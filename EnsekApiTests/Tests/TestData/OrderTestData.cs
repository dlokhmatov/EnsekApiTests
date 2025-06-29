using EnsekApiTests.Models;

namespace EnsekApiTests.Tests.TestData
{
    public static class OrderTestData
    {
        public static Order CreateOrder() => new()
        {
            Id = "1",
            Quantity = 100,
            EnergyId = 0
        };
    }
}
