using System;
using System.Collections.Generic;
using System.Linq;

namespace Finance.ModulusChecking.Domain
{
    public class ModulusWeightingTable
    {
        private const int MinDigit = 1;
        private const int MaxDigit = 14;
        private readonly IEnumerable<ModulusWeightingDetails> _modulusWeightings;

        public ModulusWeightingTable(IEnumerable<ModulusWeightingDetails> modulusWeightings)
        {
            if (modulusWeightings == null)
            {
                throw new ArgumentNullException(nameof(modulusWeightings));
            }

            var requiredNumbersList = Enumerable.Range(MinDigit, MaxDigit).Select(n => new ModulusWeightingDigit(n)).ToList();
            bool allfound = true;
            foreach (var digit in requiredNumbersList)
            {
                if (!modulusWeightings.Any(m => m.Contains(digit)))
                {
                    allfound = false;
                }
            }

            if (!allfound)
            {
                throw new ArgumentException(nameof(modulusWeightings));
            }

            _modulusWeightings = modulusWeightings;
        }

        public ModulusWeightingDetails Find(BankDetails bankDetails)
        {
            return _modulusWeightings.FirstOrDefault(m => String.Compare(bankDetails.SortCode, m.FromSortCode, StringComparison.Ordinal) >= 0 && String.Compare(bankDetails.SortCode, m.ToSortCode, StringComparison.Ordinal) <= 0);
        }
    }
}