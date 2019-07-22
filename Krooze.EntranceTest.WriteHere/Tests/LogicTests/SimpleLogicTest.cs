using Krooze.EntranceTest.WriteHere.Structure.Model;
using System.Linq;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class SimpleLogicTest
    {
        public decimal? GetOtherTaxes(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, gets if there is some other tax that not the port charge1;
            return ((cruise.TotalValue - cruise.PortCharge) - cruise.CabinValue);
        }

        public bool? IsThereDiscount(CruiseDTO cruise)
        {
            //TODO: Based on the CruisesDTO object, check if the second passenger has some kind of discount, based on the first passenger price
            //Assume there are always 2 passengers on the list
            var Passengers = cruise.PassengerCruise.OrderBy(t => t.PassengerCode);
            return Passengers.Last().Cruise.CabinValue < Passengers.First().Cruise.CabinValue;
        }

        public int? GetInstallments(decimal fullPrice)
        {
            //TODO: Based on the full price, find the max number of installments
            // -The absolute max number is 12
            // -The minimum value of the installment is 200

            if (fullPrice >= 200)
            {
                var MaxNumber = (int)(fullPrice / 200);
                return MaxNumber > 12 ? 12 : MaxNumber;
            }
            return 1; 
        }
    }
}
