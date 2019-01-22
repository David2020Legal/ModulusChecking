namespace Finance.ModulusChecking.Domain
{
    public class StandardModulusCheck : IModulusCheck
    {
        private readonly ModulusParameters _modulusParameters;

        public StandardModulusCheck(ModulusParameters modulusParameters)
        {
            _modulusParameters = modulusParameters;
        }

        public bool IsValid(BankDetails bankDetails)
        {
            var totalScore = 0;
            for (var i = 0; i < bankDetails.VerificationValue.Length; i++)
            {
                totalScore += _modulusParameters.GetWeighting(new ModulusWeightingDigit(i + 1), bankDetails.VerificationValue);
            }

            if (_modulusParameters.CheckingMethod == ModulusCheckingMethod.StandardTen || _modulusParameters.CheckingMethod == ModulusCheckingMethod.AlternateDouble)
            {
                return totalScore % 10 == 0;
            }
            else
            {
                return totalScore % 11 == 0;
            }
        }
    }
}