using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Finance.ModulusChecking.Domain.Tests
{
    [TestFixture]
    public class BankDetailsTests
    {
        [TestCase("441908")]
        [TestCase("718800")]
        [TestCase("202990")]
        public void SortCode_ValidSortCode_MatchesExpectedValue(string expectedSortCode)
        {
            // Arrange
            var bankDetails = new BankDetails(expectedSortCode, "50559977");

            // Act
            var finalSortCode = bankDetails.SortCode;

            // Assert

            Assert.AreEqual(expectedSortCode, finalSortCode);
        }

        [TestCase("50559977")]
        [TestCase("31221174")]
        [TestCase("53225471")]
        public void AccountNo_ValidSortCode_MatchesExpectedValue(string expectedAccountNo)
        {
            // Arrange
            var bankDetails = new BankDetails("202090", expectedAccountNo);

            // Act
            var finalAccountNo = bankDetails.AccountNo;

            // Assert
            Assert.AreEqual(expectedAccountNo, finalAccountNo);
        }

        [TestCase("208876","65789009", "20887665789009")]
        [TestCase("461173", "12345678", "46117312345678")]
        [TestCase("958131", "11229908", "95813111229908")]
        public void VerificationValue_PassValidAccountNoAndSortCode_ReturnsStringAppendingAccountNoToSortCode(string expectedSortCode, string expectedAccountNo, string expectedVerificationValue)
        {
            // Arrange
            var bankDetails = new BankDetails(expectedSortCode, expectedAccountNo);

            // Act
            var verificationValue = bankDetails.VerificationValue;

            Assert.AreEqual(expectedVerificationValue,verificationValue);
        }

        [Test]
        public void Constructor_NullSortCode_ThrowsNullArgumentException()
        {
            // Arrange / Act 
            var exception = Assert.Throws<ArgumentNullException>(() => new BankDetails(null, "20989911"));

            // Assert
            Assert.AreEqual("sortCode", exception.ParamName);
        }

        [Test]
        public void Constructor_NullAccountNo_ThrowsNullArgumentException()
        {
            // Arrange / Act 
            var exception = Assert.Throws<ArgumentNullException>(() => new BankDetails("202090", null));

            // Assert
            Assert.AreEqual("accountNo", exception.ParamName);
        }
    }
}
