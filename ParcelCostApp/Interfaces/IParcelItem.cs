using ParcelCostApp.Enums;

namespace ParcelCostApp.Interfaces
{
    public interface IParcelItem 
    {
        string name { get; set; }
        int dimension { get; set; }
        ParcelTypeEnum parcelType { get; set; }
        double cost { get; set; }

        void CalculateCost();
    }
}
