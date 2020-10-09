using ParcelCostApp.Interfaces;
using ParcelCostApp.Models;
using ParcelCostApp.Models.Discount;
using ParcelCostApp.Tests.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ParcelCostApp.Tests
{ 
    public class CalculateSpeedyParcelCostTest
    {
        IDiscountList _discountList = new DiscountList();
        IDiscountCalculation _discountCalculation;

        public CalculateSpeedyParcelCostTest()
        {
            _discountCalculation = new DiscountCalculation(_discountList);
        }

        [Fact]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_WhenNoItemsAreProvided()
        {
            IParcelItemList list = new ParcelItemList();

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
            Assert.True(result.speedyShippingCost == 0);
        }

        [Fact]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_WhenInvalidDimensionIsProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(-100, "TestItem5")
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
            Assert.True(result.speedyShippingCost == 0);
        }


        [Theory]
        [InlineData(5, 6, 3)]
        [InlineData(24, 16, 8)]
        [InlineData(78, 30, 15)]
        [InlineData(1888, 50, 25)]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_WhenValidDimensionIsProvided(
            int dimension, double expectedCost, double expectedShippingCost)
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(dimension, "TestItem")
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
             SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 1);
            Assert.True(result.totalCost == expectedCost);
            Assert.True(result.speedyShippingCost == expectedShippingCost);
        }

        [Fact]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_WhenMultipleValidDimensionAreProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(6, "TestItem1"),
                TestUtilities.GenerateParcelItem(24, "TestItem2"),
                TestUtilities.GenerateParcelItem(75, "TestItem3"),
                TestUtilities.GenerateParcelItem(500, "TestItem4"),
                TestUtilities.GenerateParcelItem(-100, "TestItem5")
            };

            var expectedOrderCost = 51;
            var expectedCount = 4;

            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalCost == expectedOrderCost * 2);
            Assert.True(result.speedyShippingCost == expectedOrderCost);
        }

        [Fact]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_AfterApplyingDiscountForSmallParcels()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(6, "TestItem1"),
                TestUtilities.GenerateParcelItem(5, "TestItem2"),
                TestUtilities.GenerateParcelItem(3, "TestItem3"),
                TestUtilities.GenerateParcelItem(8, "TestItem4"),
                TestUtilities.GenerateParcelItem(4, "TestItem5"),
                TestUtilities.GenerateParcelItem(5, "TestItem6"),
                TestUtilities.GenerateParcelItem(6, "TestItem7"),
                TestUtilities.GenerateParcelItem(-100, "TestItem8"),
                TestUtilities.GenerateParcelItem(9, "TestItem9"),
            };
            var expectedOrderCost = 15;
            var expectedCount = 8;
            var totalDiscount = -9;
            
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalDiscount == totalDiscount);
            Assert.True(result.totalCost == expectedOrderCost * 2);
            Assert.True(result.speedyShippingCost == expectedOrderCost);
        }

        [Fact]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_AfterApplyingDiscountForMediumParcels()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(28, "TestItem1"),
                TestUtilities.GenerateParcelItem(25, "TestItem2"),
                TestUtilities.GenerateParcelItem(23, "TestItem3"),
                TestUtilities.GenerateParcelItem(25, "TestItem4"),
                TestUtilities.GenerateParcelItem(24, "TestItem5"),
                TestUtilities.GenerateParcelItem(-100, "TestItem8"),
            };
            var expectedOrderCost = 32;
            var expectedCount = 5;
            var totalDiscount = -8;

            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalDiscount == totalDiscount);
            Assert.True(result.totalCost == expectedOrderCost * 2);
            Assert.True(result.speedyShippingCost == expectedOrderCost);
        }

        [Fact]
        public void Test_SpeedyParcelCost_IsReturnedCorrectly_AfterApplyingDiscountForMixedParcels()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(4, "TestItem1"),
                TestUtilities.GenerateParcelItem(5, "TestItem2"),
                TestUtilities.GenerateParcelItem(23, "TestItem3"),
                TestUtilities.GenerateParcelItem(25, "TestItem4"),
                TestUtilities.GenerateParcelItem(90, "TestItem5"),
                TestUtilities.GenerateParcelItem(3, "TestItem6"),
                TestUtilities.GenerateParcelItem(5, "TestItem7"),
                TestUtilities.GenerateParcelItem(22, "TestItem8"),
                TestUtilities.GenerateParcelItem(26, "TestItem9"),
                TestUtilities.GenerateParcelItem(95, "TestItem10"),
                TestUtilities.GenerateParcelItem(-100, "TestItem11"),
            }; 
            var expectedOrderCost = 60; 
            var expectedCount = 10;
            var totalDiscount = -14;

            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new SpeedyParcelCostCalculation(list, _discountCalculation);
            SpeedyParcelCostResult result = (SpeedyParcelCostResult)calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalDiscount == totalDiscount);
            Assert.True(result.totalCost == expectedOrderCost * 2);
            Assert.True(result.speedyShippingCost == expectedOrderCost);
        }
    }
}
