using NUnit.Framework;

namespace Finance.ModulusChecking.Domain.Tests
{
    [TestFixture]
    public class StandardModulusCheckTests
    {
        [TestCase("089999", "66374958", ModulusCheckingMethod.StandardTen)]
        [TestCase("102400","88837491", ModulusCheckingMethod.StandardEleven)]
        public void IsValid_ValidAccountDetails_ReturnsTrue(string sortCode, string accountNo, ModulusCheckingMethod checkingMethod)
        {
            // Arrange
            var bankDetails = new BankDetails(sortCode, accountNo);
            var modulusParametersFactory = new ModulusParametersFactory(ModulusTestHelper.CreateStandardWeightingTable(checkingMethod));
            var modulusParameters = modulusParametersFactory.CreateModulusParameters(bankDetails);
            var standardModulusCheck = new StandardModulusCheck(modulusParameters);

            // Act
            var result = standardModulusCheck.IsValid(bankDetails);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
