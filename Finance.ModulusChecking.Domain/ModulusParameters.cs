namespace Finance.ModulusChecking.Domain
{
    public class ModulusParameters
    {
        private readonly ModulusWeightingDetails _modulusWeightingDetails;

        public ModulusParameters(ModulusCheckingMethod checkingMethod, ModulusWeightingDetails modulusWeightingDetails)
        {
            _modulusWeightingDetails = modulusWeightingDetails;
            CheckingMethod = checkingMethod;
        }

        public ModulusCheckingMethod CheckingMethod { get; set; }

        public int GetWeighting(ModulusWeightingDigit modulusWeightingDigit, string accountDetailsValue)
        {
            if (_modulusWeightingDetails == null)
            {
                return -1;
            }
            else
            {
                return _modulusWeightingDetails.GetScore(modulusWeightingDigit, accountDetailsValue);
            }
        }
    }
}