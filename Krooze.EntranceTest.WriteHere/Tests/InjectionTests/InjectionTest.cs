using System.Collections.Generic;
using Krooze.EntranceTest.WriteHere.Structure.Implementations;
using Krooze.EntranceTest.WriteHere.Structure.Interfaces;
using Krooze.EntranceTest.WriteHere.Structure.Model;

namespace Krooze.EntranceTest.WriteHere.Tests.InjectionTests
{
    public class InjectionTest
    {
        private readonly InjectionMap<CruiseRequestDTO> _mapCompanies;

        public InjectionTest()
        {
            this._mapCompanies = new InjectionMap<CruiseRequestDTO>();
            MapInjection();
        }

        private void MapInjection()
        {
            this._mapCompanies.Map(typeof(Company1), t => t.CruiseCompanyCode == 1);
            this._mapCompanies.Map(typeof(Company2), t => t.CruiseCompanyCode == 2);
            this._mapCompanies.Map(typeof(Company3), t => t.CruiseCompanyCode == 3);
        }

        public List<CruiseDTO> GetCruises(CruiseRequestDTO request)
        {
            //TODO: This method receives a generic request, that has a cruise company code on it
            //There is an interface (IGetCruise) that is implemented by 3 classes (Company1, Company2 and Company3)
            //Make sure that the correct class is injected based on the CruiseCompanyCode on the request
            //and the method GetCruises on it is called

            return this._mapCompanies.Factory<IGetCruise>(request).GetCruises(request);
        }
    }
}
