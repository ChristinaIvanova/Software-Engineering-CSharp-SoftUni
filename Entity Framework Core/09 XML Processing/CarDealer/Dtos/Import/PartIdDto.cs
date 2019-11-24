using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlRoot("parts")]
    public class PartIdDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
