using System.Collections.Generic;

namespace ParcelCostApp.Interfaces
{
    /*
     DiscountList implements IDiscountList to hold a list 
    of all types of discounts. If a new discount is introduced,
    add that discount type to this list
     */
    public interface IDiscountList
    {
        IEnumerable<IDiscountType> discountTypes { get; set; }
    }
}
