using ParcelCostApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParcelCostApp.Tests.Utils
{
    public static class TestUtilities
    {
        public static ParcelItem GenerateParcelItem(int dimension, string name)
        {
            return new ParcelItem
            {
                dimension = dimension,
                name = name
            };
        }

    }
}
