using ParcelCostApp.Interfaces;
using ParcelCostApp.Models;
using ParcelCostApp.Models.Discount;
using ParcelCostApp.Tests.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ParcelCostApp.Tests
{ 
    public class CalculateParcelCostTestWithLimit
    {
        IDiscountList _discountList = new DiscountList();
        IDiscountCalculation _discountCalculation;
        
        public CalculateParcelCostTestWithLimit()
        {
            _discountCalculation = new DiscountCalculation(_discountList);
        }

        [Fact]
        public void Test_ParcelCostWithWeightLimit_IsReturnedCorrectly_WhenInvalidDimensionAndWeightIsProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(-100, "TestItem5", 100)
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
            Assert.True(result.speedyShippingCost == 0);
        }

        [Theory]
        //Below weight limit
        [InlineData(5, 0, 6, 3)]
        [InlineData(24, 2, 16, 8)]
        [InlineData(78, 5, 30, 15)]
        [InlineData(1888, 8, 50, 25)]
        
        //Above weight limit
        [InlineData(5, 3, 14, 7)]
        [InlineData(24, 5, 24, 12)] 
        [InlineData(78, 8, 38, 19)]
        [InlineData(1888, 12, 58, 29)]

        //Heavy Parcel Type
        [InlineData(1888, 100, 200, 100)] 
        public void Test_ParcelCostWithWeightLimit_IsReturnedCorrectly_WhenValidDimensionAndWeightIsProvided(
            int dimension, double weight, double expectedCost, double expectedShippingCost)
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(dimension, "TestItem", weight)
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 1);
            Assert.True(result.totalCost == expectedCost);
            Assert.True(result.speedyShippingCost == expectedShippingCost);
        }

        [Fact]
        public void Test_ParcelCostWithWeightLimit_IsReturnedCorrectly_WhenMultipleValidDimensionAreProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(5, "TestItem1", 0),
                TestUtilities.GenerateParcelItem(5, "TestItem2", 3),
                TestUtilities.GenerateParcelItem(24, "TestItem3", 2),
                TestUtilities.GenerateParcelItem(24, "TestItem4", 5),
                TestUtilities.GenerateParcelItem(78, "TestItem5", 5),
                TestUtilities.GenerateParcelItem(78, "TestItem6", 8),
                TestUtilities.GenerateParcelItem(1888, "TestItem7", 8),
                TestUtilities.GenerateParcelItem(1888, "TestItem8", 12),
                TestUtilities.GenerateParcelItem(-100, "TestItem9", 10)
            }; 
            var expectedOrderCost = 115;
            var expectedCount = 8;
            var expectedDiscount = -3;
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalDiscount == expectedDiscount);
            Assert.True(result.totalCost == expectedOrderCost * 2);
            Assert.True(result.speedyShippingCost == expectedOrderCost);

        }
    }
}
