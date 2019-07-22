using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.LogicTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogicController : ControllerBase
    {
        private readonly SimpleLogicTest _simpleLogictest;

        public LogicController()
        {
            this._simpleLogictest = new SimpleLogicTest();
        }

        [HttpPost("Dicscount")]
        public bool Discount([FromBody] CruiseDTO CruiseDTO) => 
           (bool)this._simpleLogictest.IsThereDiscount(CruiseDTO);

        [HttpGet("Installments/Price={Price}")]
        public int Installments([FromRoute] decimal Price) => 
           (int)this._simpleLogictest.GetInstallments(Price);

        [HttpPost("OtherTaxes")]
        public void OtherTaxes([FromBody] CruiseDTO CruiseDTO) =>
            this._simpleLogictest.GetOtherTaxes(CruiseDTO);
    }
}