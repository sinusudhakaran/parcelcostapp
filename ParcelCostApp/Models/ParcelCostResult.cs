using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models
{
    public class ParcelCostResult : IParcelCostResult
    {
        public IEnumerable<IParcelItem> parcels { get; set; } = new List<IParcelItem>();
        public double totalCost { get; set; } = 0;

        public void AddParcels()
        {

        }

        public void CalculateTotalCost()
        {
            parcels.ToList().ForEach(parcel =>
            {
                parcel.CalculateCost();
                totalCost += parcel.cost;
            });
        }
    }

}
