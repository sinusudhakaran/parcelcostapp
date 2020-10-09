using System.Collections.Generic;

namespace ParcelCostApp.Interfaces
{
    /*
    DiscountCalculation implements IDiscountCalculation to go thru 
    a list of various discount types to calculate discount
    */
    public interface IDiscountCalculation
    {
        IEnumerable<IParcelItem> ApplyDiscount(IEnumerable<IParcelItem> parcels);
    }
}
