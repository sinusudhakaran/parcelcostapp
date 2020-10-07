
using ParcelCostApp.Interfaces;
using System.Collections.Generic;

namespace ParcelCostApp.Models
{
    public class ParcelItemList : IParcelItemList
    {
        public IEnumerable<IParcelItem> parcels { get; set; }
        
        public ParcelItemList()
        {
            parcels = new List<IParcelItem>();
        }
    }
}
