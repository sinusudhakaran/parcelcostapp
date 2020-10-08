using ParcelCostApp.Models;

namespace ParcelCostApp.Tests.Utils
{
    public static class TestUtilities
    {
        public static ParcelItem GenerateParcelItem(int dimension, string name, double weight = 0)
        {
            return new ParcelItem
            {
                dimension = dimension,
                name = name,
                weight = weight
            };
        }

    }
}
