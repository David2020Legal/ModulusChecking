using System;

namespace Finance.ModulusChecking.Domain
{
    public class BankDetails
    {
        public BankDetails(string sortCode, string accountNo)
        {
            if (sortCode == null)
            {
                throw new ArgumentNullException(nameof(sortCode));
            }

            if (accountNo == null)
            {
                throw new ArgumentNullException(nameof(accountNo));
            }
            SortCode = sortCode;
            AccountNo = accountNo;
        }

        public string SortCode { get; }
        public string AccountNo { get; }
        public string VerificationValue => string.Concat(SortCode, AccountNo);
    }
}