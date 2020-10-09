using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models
{
    public class SpeedyParcelCostCalculation : ParcelCostCalculation
    {
        public double speedyShippingCost { get; set; }

        public SpeedyParcelCostCalculation(IParcelItemList list, IDiscountCalculation discountCalculation) : base(list, discountCalculation)
        {
            _list = list;
        }

        public override ParcelCostResult CalculateCost()
        {
            SpeedyParcelCostResult result = new SpeedyParcelCostResult();
            var validParcelCost = base.CalculateCost();

            result.parcels = validParcelCost.parcels;
            result.speedyShippingCost = validParcelCost.totalCost;
            result.totalCost = validParcelCost.totalCost + result.speedyShippingCost;
            result.totalDiscount = -1 * validParcelCost.totalDiscount;

            return result;
        }
    }
}

