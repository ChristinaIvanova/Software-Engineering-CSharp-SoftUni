using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using CarDealer.Models;

namespace CarDealer.Dtos.Export
{
    [XmlType("customer")]
   public class CustomerDtoExport
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCarsCount { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }
    }
}
