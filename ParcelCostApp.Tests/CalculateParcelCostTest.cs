using ParcelCostApp.Interfaces;
using ParcelCostApp.Models;
using ParcelCostApp.Models.Discount;
using ParcelCostApp.Tests.Utils;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ParcelCostApp.Tests
{ 
    public class CalculateParcelCostTest
    {
        IDiscountList _discountList = new DiscountList();
        IDiscountCalculation _discountCalculation;

        public CalculateParcelCostTest()
        {
            _discountCalculation = new DiscountCalculation(_discountList);
        }

        [Fact]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenNoItemsAreProvided()
        {
            IParcelItemList list = new ParcelItemList();

            var calculation = new ParcelCostCalculation(list, _discountCalculation);
            var result = calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
        }

        [Fact]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenInvalidDimensionIsProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(-100, "TestItem5")
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new ParcelCostCalculation(list, _discountCalculation);
            var result = calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(5, 3, 1)]
        [InlineData(9, 3, 1)]
        [InlineData(10, 8, 1)]
        [InlineData(11, 8, 1)]
        [InlineData(24, 8, 1)]
        [InlineData(49, 8, 1)]
        [InlineData(50, 15, 1)]
        [InlineData(78, 15, 1)]
        [InlineData(99, 15, 1)]
        [InlineData(100, 25, 1)]
        [InlineData(1888, 25, 1)]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenValidDimensionIsProvided
            (int dimension, double expectedCost, int expectedCount)
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(dimension, "TestItem")
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new ParcelCostCalculation(list, _discountCalculation);
            var result = calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalCost == expectedCost);
        }

        [Fact]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenMultipleValidDimensionAreProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                TestUtilities.GenerateParcelItem(6, "TestItem1"),
                TestUtilities.GenerateParcelItem(24, "TestItem2"),
                TestUtilities.GenerateParcelItem(75, "TestItem3"),
                TestUtilities.GenerateParcelItem(500, "TestItem4"),
                TestUtilities.GenerateParcelItem(-100, "TestItem5")
            };

            var expectedCost = 51;
            var expectedCount = 4;

            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new ParcelCostCalculation(list, _discountCalculation);
            var result = calculation.CalculateCost();

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalCost == expectedCost);
        }
    }
}
