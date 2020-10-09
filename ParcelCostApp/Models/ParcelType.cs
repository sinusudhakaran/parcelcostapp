using ParcelCostApp.Enums;

namespace ParcelCostApp.Models
{
    public static class ParcelType
    {
        public static ParcelTypeEnum getParcelType(int dimension, double weight=0)
        {
            if (dimension < 10) return ParcelTypeEnum.Small;
            if (dimension < 50) return ParcelTypeEnum.Medium;
            if (dimension < 100) return ParcelTypeEnum.Large;

            if (weight > 50) return ParcelTypeEnum.Heavy; 
            
            return ParcelTypeEnum.XL;
        }
    }
}
