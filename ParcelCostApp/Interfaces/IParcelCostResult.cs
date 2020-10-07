using System.Collections.Generic;

namespace ParcelCostApp.Interfaces
{
    public interface IParcelCostResult
    {
        IEnumerable<IParcelItem> parcels { get; set; }
        double totalCost { get; set; }

        void CalculateTotalCost();
        void AddParcels();
    }
}
