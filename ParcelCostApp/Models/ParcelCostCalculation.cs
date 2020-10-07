using ParcelCostApp.Interfaces;
using ParcelCostApp.Models;
using System.Linq;

namespace ParcelCostApp
{
    /*
     It's hard for customers to decide dimension and size conversion. 
    So instead of chosing size as input , I am thinking to have 
    dimension as input socustomer can just enter the dimension and system can decide
    which size is that.
     */

    public class ParcelCostCalculation : IParcelCostCalculation
    {
        private IParcelItemList Validate(IParcelItemList list)
        {
            var validList = new ParcelItemList();
            
            validList.parcels = list.parcels.ToList()
                .Where(parcel => parcel.dimension > 0);
            
            return validList;
        }

        public virtual ParcelCostResult CalculateCost(IParcelItemList list)
        {
            var validList = Validate(list);

            ParcelCostResult result = new ParcelCostResult() { parcels = validList.parcels };
            result.CalculateTotalCost();

            return result;
        }
    }
}
