using System.Collections.Generic;
using System.Linq;
using Finance.ModulusChecking.Domain;

namespace Finance.ModulusChecking.Dto
{
    public class ModulusWeightingFactory
    {
        public ModulusWeightingDetails Create(WeightingDto weightingDto)
        {
            return new ModulusWeightingDetails(weightingDto.SortCodeFrom, weightingDto.SortCodeTo, ToModulusCheckingMethod(weightingDto.Method), weightingDto.WeightingValues.Select(v => new IndiviualModulusWeighting(new ModulusWeightingDigit(v.Digit), v.Value )));
        }

        private ModulusCheckingMethod ToModulusCheckingMethod(ModulusMethod sourceMethod)
        {
            switch (sourceMethod)
            {
                case ModulusMethod.MOD10:
                    return ModulusCheckingMethod.StandardTen;
                case ModulusMethod.MOD11:
                    return ModulusCheckingMethod.StandardEleven;
                case ModulusMethod.DBLAL:
                    return ModulusCheckingMethod.AlternateDouble;
                default:
                    return ModulusCheckingMethod.None;
            }
        }
    }
}