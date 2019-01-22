using NUnit.Framework;

namespace Finance.ModulusChecking.Domain.Tests
{
    [TestFixture]
    public class AccountDetailsCheckerTests
    {
        [TestCase("089999", "66374958", true, ModulusCheckingMethod.StandardTen)]
        [TestCase("089999", "66373422", false, ModulusCheckingMethod.StandardTen)]
        [TestCase("000000", "66373422", false, ModulusCheckingMethod.StandardTen)]
        public void Check_ValidLookingAccountDetails_ReturnsSuccessOrFailureCorrectly(string sortCode, string accountNo, bool expectedSuccess, ModulusCheckingMethod method)
        {
            // Arrange
            var accountDetails = new BankDetails(sortCode, accountNo);
            var modulusWeightingTable = ModulusTestHelper.CreateStandardWeightingTable(method);
            var accountDetailsChecker = new AccountDetailsChecker(modulusWeightingTable);

            // Act
            var accountCheckResult = accountDetailsChecker.Check(accountDetails);

            // Assert
            Assert.AreEqual(expectedSuccess, accountCheckResult.Success);

        }
    }
}
