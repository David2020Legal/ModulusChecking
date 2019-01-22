using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Finance.ModulusChecking.Domain;
using Finance.ModulusChecking.Dto;
using Finance.ModulusChecking.Service;

namespace ModulusChecking.Controllers
{
    public class ModulusController : ApiController
    {
        private readonly ModulusParametersFactory _modulusParametersFactory;

        public ModulusController(IWeightingsRepository weightingsRepository, ModulusWeightingFactory modulusWeightingFactory)
        {
            _modulusParametersFactory = new ModulusParametersFactory(new ModulusWeightingTable(weightingsRepository.GetAllWeightings().Select(modulusWeightingFactory.Create)));
        }

        [HttpGet]
        [Route("Modulus/sort/{sortCode}/account/{accountNo}")]
        public IHttpActionResult VerifyBankDetails(string sortCode, string accountNo)
        {
            var bankAccount = new BankDetails(sortCode, accountNo);
            var accountChecker = new StandardModulusCheck(_modulusParametersFactory.CreateModulusParameters(bankAccount));
            return Ok(new VerifyResult(accountChecker.IsValid(bankAccount)));
        }
    }

    public class VerifyResult
    {
        public bool Success { get; }

        public VerifyResult(bool success)
        {
            Success = success;
        }
    }
}
