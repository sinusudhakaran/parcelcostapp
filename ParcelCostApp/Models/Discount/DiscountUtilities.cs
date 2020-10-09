using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models.Discount
{
    /*
    This is the common function called from MediumParcelMania, 
    MixedParcelMania and SmallParcelMania to update the discount of each item 
    based on the criteria
    */
    public static class DiscountUtilities
    {
        public static IEnumerable<IParcelItem> UpdateDiscountOnSpecificItem
            (IEnumerable<IParcelItem> parcels, int discountPosition)
        {
            IEnumerable<IParcelItem> result = new List<IParcelItem>();
            while (parcels.ToList().Count() >= discountPosition)
            {
                var discountSet = parcels.ToList().Take(discountPosition).ToList();
                if (discountSet.Count() == discountPosition)
                {
                    var firstItem = discountSet.First();
                    firstItem.discount = firstItem.cost;
                }

                result = result.Concat(discountSet).ToArray();

                parcels = parcels.ToList().Skip(discountPosition).ToList();
            }
            return parcels.Count() > 0? result.Concat(parcels).ToArray(): result;
        }
    }
}
