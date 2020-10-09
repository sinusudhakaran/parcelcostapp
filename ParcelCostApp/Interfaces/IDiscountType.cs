using System.Collections.Generic;

namespace ParcelCostApp.Interfaces
{
    /*
    SmallParcelMania, MediumParcelMania and MixedParcelMania implements
    IDiscountType to provide different discaount calculation menthod for
    different discount types
    */
    public interface IDiscountType
    {
        IEnumerable<IParcelItem> ApplyDiscount(IEnumerable<IParcelItem> parcels);
    }
}
