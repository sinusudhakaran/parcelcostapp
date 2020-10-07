using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models
{
    public class ParcelItem : IParcelItem
    {
        public string name { get; set; }
        public int dimension { get; set; }
        public ParcelTypeEnum parcelType { get; set; }
        public double cost { get; set; }

        public void CalculateCost()
        {
            ParcelTypeEnum parcelType = ParcelType.getParcelType(dimension);
            var parcelSizes = new ParcelSizes();

            var size = parcelSizes.getParcelSize(parcelType);
            cost = (size != null) ? size.cost : cost;
        }
    }
}
