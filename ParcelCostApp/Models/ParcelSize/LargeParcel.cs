using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models.ParcelSize
{
    public class LargeParcel : IParcelType
    {
        public ParcelTypeEnum parcelType { get; set; }
        public double cost { get; set; }
        public double weightLimit { get; set; }

        public LargeParcel()
        {
            parcelType = ParcelTypeEnum.Large;
            cost = 15.0;
            weightLimit = 6;
        }
    }
}
