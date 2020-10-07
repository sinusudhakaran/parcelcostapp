using ParcelCostApp.Interfaces;
using ParcelCostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ParcelCostApp.Tests
{ 
    public class CalculateParcelCostTest
    {
        [Fact]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenNoItemsAreProvided()
        {
            IParcelItemList list = new ParcelItemList();

            var calculation = new ParcelCostCalculation();
            var result = calculation.CalculateCost(list);

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
        }

        [Fact]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenInvalidDimensionIsProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                new ParcelItem
                {
                    dimension = -100,
                    name = "Test"
                }
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new ParcelCostCalculation();
            var result = calculation.CalculateCost(list);

            Assert.True(result.parcels.ToList().Count == 0);
            Assert.True(result.totalCost == 0);
        }

        private ParcelItem GenerateParcelItem(int dimension, string name)
        {
            return new ParcelItem
            {
                dimension = dimension,
                name = name
            };
        }

        [Theory]
        [InlineData(5, 3)]
        [InlineData(24, 8)]
        [InlineData(78, 15)]
        [InlineData(1888, 25)]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenValidDimensionIsProvided(int dimension, double expectedCost)
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                GenerateParcelItem(dimension, "TestItem")
            };
            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new ParcelCostCalculation();
            var result = calculation.CalculateCost(list);

            Assert.True(result.parcels.ToList().Count == 1);
            Assert.True(result.totalCost == expectedCost);
        }

        [Fact]
        public void Test_ParcelCost_IsReturnedCorrectly_WhenMultipleValidDimensionAreProvided()
        {
            IEnumerable<IParcelItem> parcelItems = new List<IParcelItem>()
            {
                GenerateParcelItem(6, "TestItem1"),
                GenerateParcelItem(24, "TestItem2"),
                GenerateParcelItem(75, "TestItem3"),
                GenerateParcelItem(500, "TestItem4"),
                GenerateParcelItem(-100, "TestItem5")
            };

            var expectedCost = 51;
            var expectedCount = 4;

            IParcelItemList list = new ParcelItemList() { parcels = parcelItems };

            var calculation = new ParcelCostCalculation();
            var result = calculation.CalculateCost(list);

            Assert.True(result.parcels.ToList().Count == expectedCount);
            Assert.True(result.totalCost == expectedCost);
        }
    }
}
