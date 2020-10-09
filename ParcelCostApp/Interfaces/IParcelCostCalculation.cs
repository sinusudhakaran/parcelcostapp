using ParcelCostApp.Models;

namespace ParcelCostApp.Interfaces
{
    public interface IParcelCostCalculation
    {
        ParcelCostResult CalculateCost();
    }
}
