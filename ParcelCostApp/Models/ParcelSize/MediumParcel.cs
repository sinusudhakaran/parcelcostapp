using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models.ParcelSize
{
    public class MediumParcel : IParcelType
    {
        public ParcelTypeEnum parcelType { get; set; }
        public double cost { get; set; }
        public double weightLimit { get; set; }
        public double overLimitCost { get; set; }

        public MediumParcel()
        {
            parcelType = ParcelTypeEnum.Medium;
            cost = 8.0;
            weightLimit = 3;
            overLimitCost = 2;
        }
    }
}
