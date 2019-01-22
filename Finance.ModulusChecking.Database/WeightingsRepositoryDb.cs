using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using Dapper;
using Finance.ModulusChecking.Dto;
using Finance.ModulusChecking.Service;

namespace Finance.ModulusChecking.Database
{
    public class WeightingsRepositoryDb : IWeightingsRepository
    {
        private readonly string _connectionString;

        public WeightingsRepositoryDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<WeightingDto> GetAllWeightings()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var weightings = connection.Query<WeightingDto>("SELECT Id, SortCodeFrom, SortCodeTo, Method FROM Weightings");
                var individualValues =
                    connection.Query<WeightingValue>("SELECT WeightingID, Digit, Value FROM WeightingsView");
                foreach (var weighting in weightings)
                {
                    weighting.WeightingValues = individualValues.Where(i => i.WeightingId == weighting.Id);
                }

                return weightings;
            }
        }
    }
}
