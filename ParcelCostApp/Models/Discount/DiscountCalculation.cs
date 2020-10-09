using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models.Discount
{
    /*
    Discount calculation go thru each type of dicsount type 
    (SmallMania/MediumMania/MixedMania)
    and apply respective discount to the list of parcel items
    */
    public  class DiscountCalculation : IDiscountCalculation
    {
        private IDiscountList _discountList { get; set; }
        
        public DiscountCalculation(IDiscountList discountList)
        {
            _discountList = discountList;
        }

        public IEnumerable<IParcelItem> ApplyDiscount(IEnumerable<IParcelItem> parcels)
        {
            _discountList.discountTypes.ToList().ForEach(discountType =>
            {
                parcels = parcels.ToList().OrderBy(x => x.cost);
                parcels = discountType.ApplyDiscount(parcels);
            });
            return parcels;
        }
    }
}
