
using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models
{
    public class ParcelItemList : IParcelItemList
    {
        public IEnumerable<IParcelItem> parcels { get; set; } = new List<IParcelItem>();
        
    }
}
