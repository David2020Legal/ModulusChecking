using System.Collections;
using System.Collections.Generic;

namespace Finance.ModulusChecking.Domain
{
    public class AccountDetailsChecker
    {
        private readonly ModulusWeightingTable _modulusWeightingTable;

        public AccountDetailsChecker(ModulusWeightingTable modulusWeightingTable)
        {
            _modulusWeightingTable = modulusWeightingTable;
        }

        public AccountCheckResult Check(BankDetails bankDetails)
        {
            var modulusparametersFactory = new ModulusParametersFactory(_modulusWeightingTable);
            var modulusChecker = new StandardModulusCheck(modulusparametersFactory.CreateModulusParameters(bankDetails));
            return new AccountCheckResult(modulusChecker.IsValid(bankDetails));
        }
    }

    public class AccountCheckResult
    {
        public AccountCheckResult(bool success)
        {
            Success = success;
        }
        public bool Success { get;  }
    }
}