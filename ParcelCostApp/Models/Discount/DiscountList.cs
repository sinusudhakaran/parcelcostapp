using ParcelCostApp.Interfaces;
using System.Collections.Generic;

namespace ParcelCostApp.Models.Discount
{
    /*
    This eases adding a new discount type. If a new discount type comes, 
    implement IDiscountType and add to this list so that DiscountCalculation will
    automatically picks the new discount type.
    */
    public class DiscountList : IDiscountList
    {
        public IEnumerable<IDiscountType> discountTypes { get; set; }

        public DiscountList()
        {
            discountTypes = new List<IDiscountType>()
            {
                new SmallParcelMania() ,
                new MediumParcelMania(),
                new MixedParcelMania()
            };
        }
    }
}
