using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;

namespace ParcelCostApp.Models.ParcelSize
{
    public class XLargeParcel : IParcelType
    {
        public ParcelTypeEnum parcelType { get; set; }
        public double cost { get; set; }
        public double weightLimit { get; set; }
        public double overLimitCost { get; set; }

        public XLargeParcel()
        {
            parcelType = ParcelTypeEnum.XL;
            cost = 25.0;
            weightLimit = 10;
            overLimitCost = 2;
        }
    }
}
