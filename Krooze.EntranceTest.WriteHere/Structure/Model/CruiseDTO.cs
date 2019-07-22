using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Krooze.EntranceTest.WriteHere.Structure.Model
{
    /// <summary>
    /// Cruise Transfer Object
    /// </summary>
    [XmlRootAttribute("Cruises")]
    public class CruiseDTO
    {
        [XmlElement("CruiseId")]
        public string CruiseCode { get; set; }
        /// <summary>
        /// Total Value of the Cruise
        /// </summary>
        [XmlElement("TotalAllInclusiveCabinPrice")]
        public decimal TotalValue { get; set; }
        /// <summary>
        /// Total Cabin (CAB) Value
        /// </summary>
        [XmlElement(ElementName = "CabinPrice")]
        public decimal CabinValue { get; set; }
        /// <summary>
        /// Total Port Charge (PCH) Value
        /// </summary>
        [XmlElement("PortChargesAmt")]
        public decimal PortCharge { get; set; }
        /// <summary>
        /// Ship Name
        /// </summary>
        [XmlElement("ShipName")]
        public string ShipName { get; set; }

        [XmlArray("CategoryPriceDetails")]
        [XmlArrayItem("Pax")]
        public List<PassengerCruiseDTO> PassengerCruise { get; set; }

    }

    public class PassengerCruiseDTO
    {
        private CruiseDTO _cruise;

        [XmlElement("Charge")]
        public List<ChargeDTO> Charges { set; get; }

        [XmlAttribute("PaxID")]
        public string PassengerCode { get; set; }

        public CruiseDTO Cruise
        {
            get
            {
               if (this.Charges?.Count > 0)
                {
                    return new CruiseDTO()
                    {
                        CabinValue = this.Charges.Find(t => t.ChargeType == "CAB").GrossAmount,
                        PortCharge = this.Charges.Find(t => t.ChargeType == "PCH").GrossAmount,
                        TotalValue = this.Charges.Sum(t => t.GrossAmount)
                    };
                } else
                     return this._cruise;
            }
            set { this._cruise = value; }
        }
    }

    public class ChargeDTO
    {
        [XmlAttribute("ChargeType")]
        public string ChargeType { get; set; }
        [XmlElement("GrossAmount")]
        public decimal GrossAmount { get; set; }
    }
}
