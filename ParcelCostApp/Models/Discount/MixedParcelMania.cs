using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models.Discount
{
    public  class MixedParcelMania : IDiscountType
    {
        private int MixedParcelManiaLimit = 5;
        public IEnumerable<IParcelItem> ApplyDiscount(IEnumerable<IParcelItem> parcels)
        {
            var mixedParcels = parcels.ToList()
                .Where(p => p.discount == 0).ToList();

            var discountedParcels = parcels.ToList()
                .Where(p => p.discount != 0).ToList();

            if (mixedParcels.Count() < MixedParcelManiaLimit) return parcels;

            var result = DiscountUtilities.UpdateDiscountOnSpecificItem(mixedParcels, MixedParcelManiaLimit);
            return result.Concat(discountedParcels).ToArray();
        }
    }
}
