using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models.ParcelSize
{
    public class HeavyParcel : IParcelType
    {
        public ParcelTypeEnum parcelType { get; set; }
        public double cost { get; set; }
        public double weightLimit { get; set; }
        public double overLimitCost { get; set; }

        public HeavyParcel()
        {
            parcelType = ParcelTypeEnum.Heavy;
            cost = 50.0;
            weightLimit = 50;
            overLimitCost = 1;
        }
    }
}
