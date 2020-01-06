using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string Game { get; set; }

        [XmlElement("Type")]
        public PurchaseType Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(@"[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(@"[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}\s+[0-9]{4}")]
        public string Card { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
    }
}

