using ParcelCostApp.Enums;
using System.Collections.Generic;
using ParcelCostApp.Interfaces;
using ParcelCostApp.Models.ParcelSize;

namespace ParcelCostApp
{
    public class ParcelSizes
    {
        List<IParcelType> parcelSizes;

        public ParcelSizes()
        {
            parcelSizes = new List<IParcelType>()
            {
                new SmallParcel(),
                new MediumParcel(),
                new LargeParcel(),
                new XLargeParcel()
            };
        }
 
        public IParcelType getParcelSize(ParcelTypeEnum parcelType)
        {
            return parcelSizes.Find(x => x.parcelType == parcelType);
        }
    }
}
