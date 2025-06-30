using EnsekApiTests.Models;

namespace EnsekApiTests.Tests.TestData
{
    public class OrderTestDataBuilder
    {
        private string _id = "defaultId";
        private int _quantity = 1;
        private int _energyId = 0;

        public OrderTestDataBuilder WithId(string id)
        {
            _id = id;
            return this;
        }

        public OrderTestDataBuilder WithQuantity(int quantity) 
        {
            _quantity = quantity;
            return this;
        }

        public OrderTestDataBuilder WithEnergyId(int energyId)
        {
            _energyId = energyId;
            return this;
        }

        public Order Build()
        {
            return new Order
            {
                Id = _id,
                Quantity = _quantity,
                EnergyId = _energyId,
            };
        }
    }
}
