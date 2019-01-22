using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Finance.ModulusChecking.Domain
{
    public class ModulusParametersFactory
    {
        private readonly ModulusWeightingTable _modulusWeightingTable;

        public ModulusParametersFactory(ModulusWeightingTable modulusWeightingTable)
        {
            _modulusWeightingTable = modulusWeightingTable;
        }

        public ModulusParameters CreateModulusParameters(BankDetails bankAccount)
        {
            var modulusWeighting = _modulusWeightingTable.Find(bankAccount);
            ModulusCheckingMethod modulusCheckingMethod;

            if (modulusWeighting == null)
            {
                modulusCheckingMethod = ModulusCheckingMethod.None;
            }
            else
            {
                modulusCheckingMethod = modulusWeighting.CheckingMethod;
            }

            return new ModulusParameters(modulusCheckingMethod, modulusWeighting);
        }
    }

    public class ModulusWeightingDetails
    {
        private readonly IEnumerable<IndiviualModulusWeighting> _modulusWeightingValues;
        public string FromSortCode { get; }
        public string ToSortCode { get; }
        public ModulusCheckingMethod CheckingMethod { get; }

        public ModulusWeightingDetails(string fromSortCode, string toSortCode, ModulusCheckingMethod checkingMethod, IEnumerable<IndiviualModulusWeighting> modulusWeightingValues)
        {
            _modulusWeightingValues = modulusWeightingValues;
            FromSortCode = fromSortCode;
            ToSortCode = toSortCode;
            CheckingMethod = checkingMethod;
        }

        public int GetScore(ModulusWeightingDigit digit, string accountDetailsValue)
        {
            var indiviualModulusWeighting = _modulusWeightingValues.First(w => w.IsForDigit(digit));
            return indiviualModulusWeighting.GetScore(Int32.Parse(accountDetailsValue.Substring(digit.Digit - 1, 1)));
        }

        public bool Contains(ModulusWeightingDigit digit)
        {
            return _modulusWeightingValues.Any(w => w.IsForDigit(digit));
        }
    }

    public class IndiviualModulusWeighting
    {
        private readonly ModulusWeightingDigit _weightingDigit;
        private readonly int _weighting;

        public IndiviualModulusWeighting(ModulusWeightingDigit weightingDigit, int weighting)
        {
            _weightingDigit = weightingDigit;
            _weighting = weighting;
        }

        public int GetScore(int accountDetailsValue)
        {
            return accountDetailsValue * _weighting;
        }

        public bool IsForDigit(ModulusWeightingDigit digit)
        {
            return _weightingDigit.Digit == digit.Digit;
        }
    }
}