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
        public double weight { get; set; }
        public double discount { get; set; }

        public void CalculateCost()
        {
            parcelType = ParcelType.getParcelType(dimension, weight);
            var parcelSizes = new ParcelSizes();
            var size = parcelSizes.getParcelSize(parcelType);
  
            if (size != null)
            {
                cost = size.cost + System.Math.Max(weight - size.weightLimit, 0) * size.overLimitCost;
            }
        }
    }
}
