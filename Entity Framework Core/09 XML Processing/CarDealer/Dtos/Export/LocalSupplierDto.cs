using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("supplier")]
    public class LocalSupplierDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "parts-count")]
        public int PartsCount { get; set; }
    }
}
