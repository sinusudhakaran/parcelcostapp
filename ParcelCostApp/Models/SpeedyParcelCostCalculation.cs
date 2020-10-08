using ParcelCostApp.Interfaces;
using ParcelCostApp.Models;

namespace ParcelCostApp
{
    public class SpeedyParcelCostCalculation : ParcelCostCalculation
    {
        public double speedyShippingCost { get; set; }

        public override ParcelCostResult CalculateCost(IParcelItemList list)
        {
            SpeedyParcelCostResult result = new SpeedyParcelCostResult();
            var validParcelCost = base.CalculateCost(list);

            result.parcels = validParcelCost.parcels;
            result.speedyShippingCost = validParcelCost.totalCost;
            result.totalCost = validParcelCost.totalCost + result.speedyShippingCost;

            return result;

        }
    }
}

