using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models.Discount
{
    public class SmallParcelMania : IDiscountType
    {
        private int SmallParcelManiaLimit = 4;
        public IEnumerable<IParcelItem> ApplyDiscount(IEnumerable<IParcelItem> parcels)
        {
            var smallParcels = parcels.ToList()
                .Where(p => p.parcelType == Enums.ParcelTypeEnum.Small && p.discount == 0).ToList();
            
            var discountedParcels = parcels.ToList()
                .Where(p => p.parcelType != Enums.ParcelTypeEnum.Small || p.discount != 0).ToList();

            if (smallParcels.Count() < SmallParcelManiaLimit) return parcels;

            var result = DiscountUtilities.UpdateDiscountOnSpecificItem(smallParcels, SmallParcelManiaLimit);
            return result.Concat(discountedParcels).ToArray();
        }
    }
}
