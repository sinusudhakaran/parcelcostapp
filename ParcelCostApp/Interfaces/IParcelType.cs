using ParcelCostApp.Enums;

namespace ParcelCostApp.Interfaces
{
    public interface IParcelType
    {
        ParcelTypeEnum parcelType { get; set; }
        double cost { get; set; }
        double weightLimit { get; set; }
    }
}
