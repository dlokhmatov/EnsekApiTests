namespace EnsekApiTests.Models
{
    public class EnergyEntity
    {
        public string EnergyType { get; set; }
        public int EnergyId { get; set; }
        public double PricePerUnit { get; set; }
        public int QuantityOfUnits { get; set; }
        public string UnitType { get; set; }
    }
}
