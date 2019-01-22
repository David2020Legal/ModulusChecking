using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.ModulusChecking.Dto;
using NUnit.Framework;

namespace Finance.ModulusChecking.Domain.Tests
{
    [TestFixture]
    public class WeightingDetailsFactoryTests
    {
        [TestCase("102030", "102050", ModulusMethod.DBLAL, ModulusCheckingMethod.AlternateDouble)]
        [TestCase("221178", "221180", ModulusMethod.MOD10, ModulusCheckingMethod.StandardTen)]
        [TestCase("091820", "092010", ModulusMethod.MOD11, ModulusCheckingMethod.StandardEleven)]
        public void Create_PassFullyPopulatedWeightingsDto_ReturnsObjectWithExpectedValues(string expectedFromSortCode, string expectedToSortCode, ModulusMethod sourceMethod, ModulusCheckingMethod expectedMethod)
        {
            // Arrange
            var modulusWeightingFactory = new ModulusWeightingFactory();
            var weightingDto = new WeightingDto()
            {
                SortCodeFrom = expectedFromSortCode,
                SortCodeTo = expectedToSortCode,
                Method = sourceMethod,
                WeightingValues = new List<WeightingValue>()
            };

            // Act
            var weightingDetails = modulusWeightingFactory.Create(weightingDto);

            // Assert
            Assert.AreEqual(expectedFromSortCode, weightingDetails.FromSortCode);
            Assert.AreEqual(expectedToSortCode, weightingDetails.ToSortCode);
            Assert.AreEqual(expectedMethod, weightingDetails.CheckingMethod);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void Create_AddSpecificWeighting_EnsureItIsInlist(int digit)
        {
            // Arrange
            var modulusWeightingFactory = new ModulusWeightingFactory();
            var weightingDto = new WeightingDto()
            {
                SortCodeFrom = "202020",
                SortCodeTo = "202040",
                Method = ModulusMethod.DBLAL,
                WeightingValues = new List<WeightingValue>()
                {
                    new WeightingValue()
                    {
                        WeightingId = 100,
                        Value = 0,
                        Digit = digit
                    }
                }
            };

            // Act
            var weightingDetails = modulusWeightingFactory.Create(weightingDto);

            // Assert
            Assert.AreEqual(true, weightingDetails.Contains(new ModulusWeightingDigit(digit)));
        }
    }
}
