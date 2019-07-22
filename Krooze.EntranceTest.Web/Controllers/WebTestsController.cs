using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Krooze.EntranceTest.WriteHere.Tests.WebTests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Krooze.EntranceTest.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebTestsController : ControllerBase
    {
        private readonly WebTest _webTest;

        public WebTestsController()
        {
            this._webTest = new WebTest();
        }

        [HttpGet("Movies")]
        public JObject Movies() =>
           this._webTest.GetAllMovies();

        [HttpGet("Director")]
        public string Director() =>
            this._webTest.GetDirector();
    }
}