using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krooze.EntranceTest.WriteHere.Structure.Model;
using Krooze.EntranceTest.WriteHere.Tests.InjectionTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CruisesController : ControllerBase
    {
        private readonly InjectionTest _injectionTest;

        public CruisesController()
        {
            this._injectionTest = new InjectionTest();
        }

        [HttpPost]
        public List<CruiseDTO> GetCruises([FromBody]CruiseRequestDTO CruiseRequestDTO)
        {
            return this._injectionTest.GetCruises(CruiseRequestDTO);
        }
    }
}