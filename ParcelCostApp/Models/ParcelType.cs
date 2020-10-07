using ParcelCostApp.Enums;
using ParcelCostApp.Interfaces;
using System;

namespace ParcelCostApp
{
    public static class ParcelType
    {
        public static ParcelTypeEnum getParcelType(int dimension)
        {
            if (dimension < 10) return ParcelTypeEnum.Small;
            if (dimension < 50) return ParcelTypeEnum.Medium;
            if (dimension < 100) return ParcelTypeEnum.Large;

            return ParcelTypeEnum.XL;
        }
    }
}
