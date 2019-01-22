using System.Collections.Generic;
using Finance.ModulusChecking.Dto;

namespace Finance.ModulusChecking.Service
{
    public interface IWeightingsRepository
    {
        IEnumerable<WeightingDto> GetAllWeightings();
    }
}