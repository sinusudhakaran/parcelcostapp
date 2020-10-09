using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models.Discount
{
    public class MediumParcelMania : IDiscountType
    {
        private int MediumParcelManiaLimit = 3;
        public IEnumerable<IParcelItem> ApplyDiscount(IEnumerable<IParcelItem> parcels)
        {
            var mediumParcels = parcels.ToList()
                .Where(p => p.parcelType == Enums.ParcelTypeEnum.Medium && p.discount == 0).ToList();

            var discountedParcels = parcels.ToList()
                .Where(p => p.parcelType != Enums.ParcelTypeEnum.Medium || p.discount != 0).ToList();

            if (mediumParcels.Count() < MediumParcelManiaLimit) return parcels;

            var result = DiscountUtilities.UpdateDiscountOnSpecificItem(mediumParcels, MediumParcelManiaLimit);
            return result.Concat(discountedParcels).ToArray();
        }
    }
}
