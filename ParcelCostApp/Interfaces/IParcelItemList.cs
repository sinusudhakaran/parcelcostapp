using System.Collections.Generic;

namespace ParcelCostApp.Interfaces
{
    public interface IParcelItemList
    {
        IEnumerable<IParcelItem> parcels { get; set; }
    }
}
