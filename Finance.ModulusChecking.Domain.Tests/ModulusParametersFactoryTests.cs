using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Finance.ModulusChecking.Domain.Tests
{
    [TestFixture]
    public class ModulusParametersFactoryTests
    {
        private string _standardAccountNo = "43678823";

        [Test]
        public void GetCheckingParameters_PassValidAccountDetails_ReturnsModulusParmetersObject()
        {
            // Arrange
            var modulusParamtersFactory = new ModulusParametersFactory(CreateStandardModulusWeightingTable());

            // Act
            var modulusParameters = modulusParamtersFactory.CreateModulusParameters(new BankDetails("204455",_standardAccountNo));

            // Assert
            Assert.IsNotNull(modulusParameters);
        }

        [TestCase("040082", ModulusCheckingMethod.StandardTen)]
        [TestCase("070116", ModulusCheckingMethod.StandardTen)]
        [TestCase("090129", ModulusCheckingMethod.StandardTen)]
        [TestCase("089990", ModulusCheckingMethod.StandardTen)]
        [TestCase("050000", ModulusCheckingMethod.StandardEleven)]
        [TestCase("058999", ModulusCheckingMethod.StandardEleven)]
        [TestCase("040004", ModulusCheckingMethod.AlternateDouble)]
        [TestCase("119283", ModulusCheckingMethod.AlternateDouble)]
        [TestCase("000000", ModulusCheckingMethod.None)]
        public void CreateModulusParameters_PassAccountDetailsRelatingToMethod_ReturnsSpecifiedMethod(string expectedSortCode, ModulusCheckingMethod expectedCheckingMethod)
        {
            // Arrange
            var modulusParamtersFactory = new ModulusParametersFactory(CreateStandardModulusWeightingTable());

            // Act
            var modulusParameters = modulusParamtersFactory.CreateModulusParameters(new BankDetails(expectedSortCode, _standardAccountNo));

            // Assert
            Assert.AreEqual(expectedCheckingMethod, modulusParameters.CheckingMethod);
        }

        private static ModulusWeightingTable CreateStandardModulusWeightingTable()
        {
            var zerodValuesList = Enumerable.Range(1, 14)
                .Select(n => new IndiviualModulusWeighting(new ModulusWeightingDigit(n), 0)).ToList();
            return new ModulusWeightingTable(new List<ModulusWeightingDetails>()
            { 
                new ModulusWeightingDetails("040082","040082", ModulusCheckingMethod.StandardTen, zerodValuesList),
                new ModulusWeightingDetails("050000","050000", ModulusCheckingMethod.StandardEleven, zerodValuesList),
                new ModulusWeightingDetails("040004","040004", ModulusCheckingMethod.AlternateDouble, zerodValuesList),
                new ModulusWeightingDetails("070116","070116", ModulusCheckingMethod.StandardTen, zerodValuesList),
                new ModulusWeightingDetails("090126","090129", ModulusCheckingMethod.StandardTen, zerodValuesList),
                new ModulusWeightingDetails("089000","089999", ModulusCheckingMethod.StandardTen, zerodValuesList),
                new ModulusWeightingDetails("050022","058999", ModulusCheckingMethod.StandardEleven, zerodValuesList),
                new ModulusWeightingDetails("119282","119283", ModulusCheckingMethod.AlternateDouble, zerodValuesList)
            });
        }

        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 0)]
        [TestCase(5, 0)]
        [TestCase(6, 0)]
        [TestCase(7, 42)]
        public void CreateModulusParameters_PassAccountDetails_ReturnsCorrectWeightingValues(int digit, int expectedValue)
        {
            // Arrange
            var modulusWeightingDigit = new ModulusWeightingDigit(digit);
            var bankDetails = new BankDetails("089999", "66374958");
            var modulusParametersFactory = new ModulusParametersFactory(ModulusTestHelper.CreateSingleRangeWeightingTableModulusTenPass());

            // Act
            var modulusParameters = modulusParametersFactory.CreateModulusParameters(bankDetails);

            // Assert
            Assert.AreEqual(expectedValue, modulusParameters.GetWeighting(modulusWeightingDigit, bankDetails.VerificationValue));
        }

        [TestCase("484999", "66374958")]
        [TestCase("123959", "66374958")]
        [TestCase("560929", "66374958")]
        public void CreateModulusParameters_PassAccountDetailsNotInWeightingTable_AlwaysReturnsZero(string sortCode, string accountNo)
        {
            // Arrange
            var modulusWeightingDigit = new ModulusWeightingDigit(1);
            var bankDetails = new BankDetails(sortCode, accountNo);
            var modulusParametersFactory = new ModulusParametersFactory(ModulusTestHelper.CreateSingleRangeWeightingTableModulusTenPass());

            // Act
            var modulusParameters = modulusParametersFactory.CreateModulusParameters(bankDetails);

            // Assert
            Assert.AreEqual(-1, modulusParameters.GetWeighting(modulusWeightingDigit, bankDetails.VerificationValue));
        }
    }
}
