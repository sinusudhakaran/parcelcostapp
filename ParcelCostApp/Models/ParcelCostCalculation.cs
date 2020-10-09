using ParcelCostApp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ParcelCostApp.Models
{
    /*
    It's hard for customers to decide dimension and size conversion. 
    So instead of chosing size as input , I am thinking to have 
    dimension as input so customer can just enter the dimension and system can decide
    which size is that.
     */

    public class ParcelCostCalculation : IParcelCostCalculation
    {
        protected IParcelItemList _list { get; set; }
        protected IDiscountCalculation _discountCalculation { get; set; }

        public ParcelCostCalculation(IParcelItemList list, IDiscountCalculation discountCalculation)
        {
            _list = list;
            _discountCalculation = discountCalculation;
        }

        private IEnumerable<IParcelItem> GetValidParcels()
        {
            return _list.parcels.ToList().Where(parcel => parcel.dimension > 0);
        }
        
        private void CalculateTotalCost(IEnumerable<IParcelItem> parcels, ParcelCostResult result)
        {            
            parcels.ToList().ForEach(parcel =>
            {
                result.totalCost += parcel.cost - parcel.discount;
                result.totalDiscount += parcel.discount;
            });
        }

        private void CalculateParcelItemCost(IEnumerable<IParcelItem> parcels)
        {
            parcels.ToList().ForEach(parcel =>
            {
                parcel.CalculateCost();
            });
        }

        /*
        This is the main entry point, which is called from tests.
        The constructor will get a list of all parcels as input.
        The list is validated and then calculate each item's cost 
        based on the dimension entered. After cost calculation,
        the parcel list is passed to Discount calculation interface
        to calculate discount based on the various discount types 
        allowed. Then total cost and discount are calculated 
        and send back to consumer.
        */
        public virtual ParcelCostResult CalculateCost()
        {
            var validParcels = GetValidParcels();
            CalculateParcelItemCost(validParcels);
            var discountedParcels = _discountCalculation.ApplyDiscount(validParcels);

            ParcelCostResult result = new ParcelCostResult() { parcels = discountedParcels };
            CalculateTotalCost(discountedParcels, result);

            return result;
        }
    }
}
