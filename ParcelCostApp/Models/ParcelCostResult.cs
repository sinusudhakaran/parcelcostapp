using ParcelCostApp.Interfaces;
using System.Collections.Generic;

namespace ParcelCostApp.Models
{
    /*This is the structure used to expose the results to consumers*/
    public class ParcelCostResult : IParcelCostResult
    {
        public IEnumerable<IParcelItem> parcels { get; set; } = new List<IParcelItem>();
        public double totalCost { get; set; } = 0;
        public double totalDiscount { get; set; } = 0;
    }

}
