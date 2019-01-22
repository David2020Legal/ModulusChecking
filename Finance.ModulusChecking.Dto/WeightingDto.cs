using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.ModulusChecking.Domain;

namespace Finance.ModulusChecking.Dto
{
    public class WeightingDto
    {
        public string SortCodeFrom { get; set; }
        public string SortCodeTo { get; set; }
        public ModulusMethod Method { get; set; }
        public IEnumerable<WeightingValue> WeightingValues { get;set; }
        public int Id { get; set; }
    }

    public enum ModulusMethod
    {
        MOD10,
        MOD11,
        DBLAL
    }
}
