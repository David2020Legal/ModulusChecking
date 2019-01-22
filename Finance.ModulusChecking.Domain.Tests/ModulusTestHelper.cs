using System.Collections.Generic;

namespace Finance.ModulusChecking.Domain.Tests
{
    public class ModulusTestHelper
    {
        public static ModulusWeightingTable CreateSingleRangeWeightingTableModulusTenPass()
        {
            return new ModulusWeightingTable(new List<ModulusWeightingDetails>()
            {
                new ModulusWeightingDetails("089000", "089999", ModulusCheckingMethod.StandardTen,
                    new List<IndiviualModulusWeighting>()
                    {
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(1), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(2), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(3), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(4), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(5), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(6), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(7), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(8), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(9), 3 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(10), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(11), 1),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(12), 3 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(13), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(14), 1 )
                    })
            });
        }

        public static ModulusWeightingTable CreateSingleRangeWeightingTableModulusElevenPass()
        {
            return new ModulusWeightingTable(new List<ModulusWeightingDetails>()
            {
                new ModulusWeightingDetails("102400", "107999", ModulusCheckingMethod.StandardEleven,
                    new List<IndiviualModulusWeighting>()
                    {
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(1), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(2), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(3), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(4), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(5), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(6), 0 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(7), 8 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(8), 7 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(9), 6 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(10), 5 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(11), 4),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(12), 3 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(13), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(14), 1 )
                    })
            });
        }

        public static ModulusWeightingTable CreateSingleRangeWeightingTableModulusAlternateDouble()
        {
            return new ModulusWeightingTable(new List<ModulusWeightingDetails>()
            {
                new ModulusWeightingDetails("202959", "63748472", ModulusCheckingMethod.StandardEleven,
                    new List<IndiviualModulusWeighting>()
                    {
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(1), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(2), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(3), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(4), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(5), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(6), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(7), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(8), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(9), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(10), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(11), 2),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(12), 1 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(13), 2 ),
                        new IndiviualModulusWeighting(new ModulusWeightingDigit(14), 1 )
                    })
            });
        }

        public static ModulusWeightingTable CreateStandardWeightingTable(ModulusCheckingMethod checkingMethod)
        {
            if (checkingMethod == ModulusCheckingMethod.StandardTen)
            {
                return ModulusTestHelper.CreateSingleRangeWeightingTableModulusTenPass();
            }
            else if (checkingMethod == ModulusCheckingMethod.StandardEleven)
            {
                return ModulusTestHelper.CreateSingleRangeWeightingTableModulusElevenPass();
            }
            else if (checkingMethod == ModulusCheckingMethod.AlternateDouble)
            {
                return ModulusTestHelper.CreateSingleRangeWeightingTableModulusAlternateDouble();
            }
            return new ModulusWeightingTable(new List<ModulusWeightingDetails>());
        }
    }
}