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
    public class TRanslateXMLController : ControllerBase
    {
        [HttpGet]
        public CruiseDTO TranslateXml() =>
            new XMLTest().TranslateXML();
    }
}