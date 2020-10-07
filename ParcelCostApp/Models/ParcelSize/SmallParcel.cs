using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models.ParcelSize
{
    public class SmallParcel : IParcelType
    {
        public ParcelTypeEnum parcelType { get; set; }
        public double cost { get; set; }

        public SmallParcel()
        {
            parcelType = ParcelTypeEnum.Small;
            cost = 3.0;
        }
    }
}
