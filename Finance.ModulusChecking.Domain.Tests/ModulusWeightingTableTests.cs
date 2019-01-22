using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Finance.ModulusChecking.Domain.Tests
{
    [TestFixture]
    public class ModulusWeightingTableTests
    {
        [Test]
        public void Constructor_NullModulusWeightings_ThrowsArgumentNullException()
        {
            // Arrange / Act Assert
            Assert.Throws<ArgumentNullException>(() => new ModulusWeightingTable(null));
        }

        [Test]
        public void Constructor_ModulusWeightingTableMissingWeightingDigitBetween1and14_ThrowsArgumentException()
        {
            // Arrange
            var moduusWeightingDetails = new List<ModulusWeightingDetails>();

            // Act / Asset
            Assert.Throws<ArgumentException>(() => new ModulusWeightingTable(moduusWeightingDetails));
        }
    }
}
