using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Net;

namespace Krooze.EntranceTest.WriteHere.Tests.WebTests
{
    public class WebTest
    {
        private readonly string _basepath = "https://swapi.co/api";

        private JObject Request(string EndPoint)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($@"{this._basepath}/{EndPoint}");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream Stream = response.GetResponseStream())
            using (StreamReader Reader = new StreamReader(Stream))
            {
                string ContentResponse = Reader.ReadToEnd();
                return JObject.Parse(ContentResponse);
            }
        }

        public JObject GetAllMovies()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the films object
            return this.Request("films");
        }

        public string GetDirector()
        {
            //TODO: Consume the following API: https://swapi.co/documentation using only .NET standard libraries (do not import the helpers on this page)
            // -Return the name of person that directed the most star wars movies, based on the films object return
           return this.GetAllMovies()["results"]
                        .GroupBy(r => r["director"])
                        .Select(r => new { Count = r.Count(), Director = r.Key })
                        .OrderByDescending(r => r.Count)
                        .FirstOrDefault()
                        .Director
                        .ToString();
        }
    }                   
}
